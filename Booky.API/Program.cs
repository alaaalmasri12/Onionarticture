using Microsoft.EntityFrameworkCore;
using Booky.Repostiory.Data;
using System;
using Booky.Core.IGenericRepository;
using Booky.Repostiory.GenericRepository;
using Booky.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Booky.API.DTO;
using Booky.API.MappingProfile;
using Serilog;
using Booky.Core.Ilog;
using Booky.Repostiory.Log;
using Microsoft.AspNetCore.Mvc;
using Booky.API.Customizeresponses;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddControllersWithViews(option =>
{
    option.CacheProfiles.Add("Default20", new CacheProfile()
    {
        Duration = 20,
        Location = ResponseCacheLocation.Client,
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var test = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<OnionBookyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IgenericRepoistory<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IPagenation<>), typeof(Pageniation<>));
builder.Services.AddScoped(typeof(IunitofWork), typeof(UnitofWork));

builder.Services.AddSingleton(typeof(Ilogging), typeof(Logging));
builder.Services.Configure<ApiBehaviorOptions>(option =>
{
    option.InvalidModelStateResponseFactory = (endpointContext) =>
    {
        var Errors = endpointContext.ModelState.Where(p => p.Value.Errors.Count() > 0).SelectMany(arrayopferror => arrayopferror.Value.Errors).Select(errortxt => errortxt.ErrorMessage);
        var errorresponse = new ErrorResponse()
        {
            errors = Errors
        };
        BadRequestObjectResult obj = new BadRequestObjectResult(errorresponse);
        return obj;
    };
});
builder.Services.AddAutoMapper(m => m.AddProfile(typeof(EstateProfile)));
builder.Host.UseSerilog();
Log.Logger=new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("Log/EstateLog.txt",rollingInterval:RollingInterval.Infinite).CreateLogger();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();