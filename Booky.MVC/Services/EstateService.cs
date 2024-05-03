using Booky.MVC.DTO;
using Booky.MVC.Models;
using Booky.MVC.Services.Iservices;
using static Booky.Utility.StaticDetails;

namespace Booky.MVC.Services
{
    public class EstateService :BaseService, Ibookyservice
    {
        private readonly IHttpClientFactory _httpClient;
        private string ApiURL;
        public EstateService(IHttpClientFactory httpClient,IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            ApiURL = configuration.GetValue<string>("ServicesUrl:Apiurl");
        }

        public async Task<T> CreateAsync<T>(EstateDto estateDto)
        {
            var request = new ApiRequest();
            request.data = estateDto;
            request.ApiType = ApiType.POST;
            request.Url = ApiURL+"/api/Estate/";
            return await sendAsunc<T>(request);
        }

        public async Task<T> DeleteAsync<T>(int id)
        {
            var request = new ApiRequest();
            request.ApiType = ApiType.DELETE;
            request.Url = ApiURL + "/api/Estate/"+id;
            return await sendAsunc<T>(request);
        }

        public async Task<T> getAllAsync<T>()
        {

            var request = new ApiRequest();

            request.ApiType = ApiType.GET;
            request.Url = "https://localhost:7227/api/Estate/";
            return await sendAsunc<T>(request);
        }

        public async Task<T> getbyidAsync<T>(int id)
        {
            var request = new ApiRequest();

            request.ApiType = ApiType.GET;
            request.Url = "https://localhost:7227/api/Estate/"+id;
            return await sendAsunc<T>(request);
        }

        public async Task<T> UpdateAsync<T>(EstateDto estateDto)
        {
            var request = new ApiRequest();
            request.data = estateDto;
            request.ApiType = ApiType.PUT;
            request.Url = ApiURL + "/api/Estate/";
            return await sendAsunc<T>(request);
        }
    }
}
