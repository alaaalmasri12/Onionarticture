using Booky.Core.IGenericRepository;
using Booky.Core.Models;
using Booky.Repostiory.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Repostiory.GenericRepository
{
    public class GenericRepository<T> : IgenericRepoistory<T> where T : class
    {
        private readonly OnionBookyDbContext onionBookyDbContext;
        public GenericRepository(OnionBookyDbContext dbContext)
        {
            onionBookyDbContext= dbContext;
        }

       
        public async Task CreateAsync(T entity)
        {
            await this.onionBookyDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T enitiy)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(IPagenation<T> pagenation)
        {
            if(typeof(T)== typeof(Estate))
            {
          

                    //return (IReadOnlyList<T>)await this.onionBookyDbContext.Estates.Include(x => x.EstateType).ToListAsync();
                    var query = (IQueryable<T>)this.onionBookyDbContext.Estates.Include(x => x.EstateType);
                    var pageinateddata = (IReadOnlyList<T>) await pagenation.ApplyPageination(query);
                    return pageinateddata;
                

            }
           
            return await this.onionBookyDbContext.Set<T>().ToListAsync();
        }

     
        public async Task<T?> Getbyid(int id)
        {
            if (typeof(T) == typeof(Estate))
            {
              return     await this.onionBookyDbContext.Estates.Include(x => x.EstateType).SingleOrDefaultAsync(p => p.Id == id) as T;
            }
            return await this.onionBookyDbContext.Set<T>().FindAsync(id);
        }

        public void Update(T enitiy)
        {
            throw new NotImplementedException();
        }
    }
}
