using AutoMapper;
using Booky.API.Customizeresponses;
using Booky.API.DTO;
using Booky.Core.IGenericRepository;
using Booky.Core.Ilog;
using Booky.Core.Models;
using Booky.Repostiory.Data;
using Booky.Repostiory.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Booky.API.Controllers
{
    [Route("api/[controller]")]
    //https://localhost:7227/api/Estate/apimethod
    [ApiController]
    public class EstateController : Controller
    {
        private readonly IMapper _Mapper;

        private readonly IgenericRepoistory<Estate> estaterepo;
        //private readonly ILogger _logger;
        private readonly Ilogging logger;
        private readonly IPagenation<Estate> _pagenation;
        private readonly IunitofWork _unitofwork;
        protected Apiresponse _apiresponse; 

        public EstateController(IgenericRepoistory<Estate> igenericRepoistory, IMapper mapper ,Ilogging Logger, IPagenation<Estate> pagenation,IunitofWork unitofWork)
        {
           this.estaterepo = igenericRepoistory;
            this._Mapper = mapper;
            this.logger = Logger;
            this._pagenation= pagenation;
            this._unitofwork = unitofWork;
            _apiresponse=new Apiresponse();
        }
        [HttpGet]
        [ResponseCache(CacheProfileName = "Default20")]
        public async Task<ActionResult<Apiresponse>> getAll([FromQuery(Name ="esate type id")] int? estatetypeid,string? StateTypeName,int? pageNumber,int? pageSize)
        {
            try
            {
                _pagenation.PageNumber = pageNumber ?? _pagenation.PageNumber;
                _pagenation.pageSize = pageSize ?? _pagenation.pageSize;
                logger.Log("get All estates", "info");
                if (estatetypeid > 0)
                {
                    var estatebyTypeid = await _unitofwork.estateRepoistory.getestateByid(estatetypeid);
                    if (estatebyTypeid is null)
                    {
                        return NotFound(new Response(404));
                    }

                    else
                    {
                        var mappedEstatesbyidDto = _Mapper.Map<IReadOnlyList<Estate>, IReadOnlyList<EstateDto>>(estatebyTypeid);
                        return Ok(mappedEstatesbyidDto);
                    }


                }
                if (StateTypeName != null)
                {
                    var estatebyTypename = await _unitofwork.estateRepoistory.Getestatebytypenamename(StateTypeName);
                    if (estatebyTypename is null)
                    {
                        return NotFound(new Response(404));
                    }

                    else
                    {
                        var mappedEstatesbynameDto = _Mapper.Map<IReadOnlyList<Estate>, IReadOnlyList<EstateDto>>(estatebyTypename);
                        return Ok(mappedEstatesbynameDto);

                    }
                }
                //var estates = await estaterepo.GetAllAsync( _pagenation);
                var estates = await _unitofwork.estateRepoistory.GetAllAsync(_pagenation);

                if (estates == null)
                {
                    _apiresponse.IsSucssess = false;
                    _apiresponse.ErrorMessages = new List<string>()
                {
"Not Estate Found"
                };

                    return NotFound(new Response(400));
                }
                //var mappedEstatesDto = _Mapper.Map<IReadOnlyList<Estate>, IReadOnlyList<EstateDto>>(estates);
                _apiresponse.Result = _Mapper.Map<IReadOnlyList<Estate>, IReadOnlyList<EstateDto>>(estates);
                _apiresponse.StatusCode = HttpStatusCode.OK;
                _apiresponse.IsSucssess = true;
                return Ok(_apiresponse);
            }
            catch (Exception ex)
            {

                _apiresponse.IsSucssess = false;
                _apiresponse.ErrorMessages = new List<string>()
                {
ex.Message
                };
                return _apiresponse;

            }
            return _apiresponse;

        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Default20")]

        public async Task<ActionResult<Apiresponse>> Getbyid(int id)
        {
            if(id ==0)
            {
                logger.Log("error not found", "error");
                return NotFound(new Response(400));

            }
            else
            {
                var Estatesbyid =await _unitofwork.estateRepoistory.Getbyid(id);
                if (Estatesbyid == null)
                {
                    return NotFound(new Response(404,"id is not found"));

                }
                var mappedEstatesDto = _Mapper.Map<Estate, EstateDto>(Estatesbyid);
                _apiresponse.Result = mappedEstatesDto;
                _apiresponse.StatusCode = HttpStatusCode.OK;
                _apiresponse.IsSucssess = true;
                return Ok(_apiresponse);
            }    
        }

        [HttpPost]

        public async Task<ActionResult<Apiresponse>> Create(EstateDto estateDto)
        {
            var mappedEstatesDto = _Mapper.Map<EstateDto, Estate>(estateDto);

            await _unitofwork.estateRepoistory.CreateAsync(mappedEstatesDto);
       var sucsses=    await _unitofwork.SaveAsync();
            if(sucsses>0)
            {
                _apiresponse.StatusCode = HttpStatusCode.OK;
                _apiresponse.IsSucssess = true;
                return Ok(_apiresponse);
            }
            else
            {
                _apiresponse.StatusCode = HttpStatusCode.BadRequest;
                _apiresponse.IsSucssess = false;
                return Ok(_apiresponse);
            }
        }


    }
}
