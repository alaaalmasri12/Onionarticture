using Booky.Core.IGenericRepository;
using Booky.Repostiory.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Repostiory.GenericRepository
{
    public class UnitofWork : IunitofWork
    {
        private readonly OnionBookyDbContext _DbContext;

        public IestateRepoistory estateRepoistory { get; set; }
        public UnitofWork(OnionBookyDbContext dbContext)
        {
            estateRepoistory = new EstateRepository(dbContext);
         
            this._DbContext = dbContext;
        }

       

        public async Task<int> SaveAsync()
        {
            return await _DbContext.SaveChangesAsync();
        }
    }
}
