using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Core.IGenericRepository
{
    public interface IgenericRepoistory<T>where T : class
    {
       Task<IReadOnlyList<T>> GetAllAsync(IPagenation<T> pagenation);
        Task<T> Getbyid(int id);
        public Task CreateAsync(T entity);

        void Update(T enitiy);

        void Delete(T enitiy);
    }
}
