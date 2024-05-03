using Booky.MVC.Models;

namespace Booky.MVC.Services.Iservices
{
    public interface IbaseService
    {
        public Apiresponse ResponseModel { get; set; }
        Task<T> sendAsunc<T>(ApiRequest apiRequest);
    }
}
