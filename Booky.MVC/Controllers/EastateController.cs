using Booky.MVC.DTO;
using Booky.MVC.Models;
using Booky.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Booky.MVC.Controllers
{
    public class EastateController : Controller
    {
        private readonly Ibookyservice ibookyservice;

        public EastateController(Ibookyservice ibookyservice)
        {
            this.ibookyservice = ibookyservice;
        }
        public async Task<IActionResult> Index()
        {
            var listofestaes=new List<EstateDto>();
         var response=await ibookyservice.getAllAsync<Apiresponse>();
            if(response !=null && response.IsSucssess)
            {
                listofestaes = JsonConvert.DeserializeObject<List<EstateDto>>(Convert.ToString(response.Result));
                return View(listofestaes);

            }
            else
            {
                return View(listofestaes);
            }
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default20")]
        public async Task<IActionResult> getall()
        {
            try
            {
                var estatesResponse = await ibookyservice.getAllAsync<Apiresponse>();

                if (estatesResponse.IsSucssess)
                {
                    var listtodo = new List<EstateDto>();
                    var estates = await ibookyservice.getAllAsync<Apiresponse>();
                    listtodo = JsonConvert.DeserializeObject<List<EstateDto>>(Convert.ToString(estates.Result));
                    return Json(new { Data = listtodo });
                }
                else
                {
                    // Handle the case where the request was not successful
                    return StatusCode((int)estatesResponse.StatusCode, "Failed to retrieve estates");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the process
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EstateDto estateDto)
        {
            if (ModelState.IsValid)
            {
                var response = await ibookyservice.CreateAsync<Apiresponse>(estateDto);
                if(response.IsSucssess && response !=null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(estateDto);
        }
    }
}
