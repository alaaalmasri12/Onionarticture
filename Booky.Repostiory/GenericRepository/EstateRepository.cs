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
    public class EstateRepository : GenericRepository<Estate>, IestateRepoistory
    {
        private readonly OnionBookyDbContext _dbContext;
        public EstateRepository(OnionBookyDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Estate>> getestateByid(int? Typeid)
        {
            return  await _dbContext.Estates.Where(x => x.EstateTypeId == Typeid).Include(x=>x.EstateType).ToListAsync();

        }

        public async Task<IReadOnlyList<Estate>> Getestatebytypenamename(string? typename)
        {
            return await _dbContext.Estates.Where(x => x.EstateType.TypeName.ToLower() == typename).ToListAsync();
        }
    }
}
