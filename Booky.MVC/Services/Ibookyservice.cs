using Booky.MVC.DTO;

namespace Booky.MVC.Services
{
    public interface Ibookyservice
    {
        Task<T> getAllAsync<T>();
        Task<T> getbyidAsync<T>(int id);
        Task<T> CreateAsync<T>(EstateDto estateDto);
        Task<T> UpdateAsync<T>(EstateDto estateDto);
        Task<T> DeleteAsync<T>(int id);

    }
}
