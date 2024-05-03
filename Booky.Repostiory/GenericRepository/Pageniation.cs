using Booky.Core.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Repostiory.GenericRepository
{
    public class Pageniation<T> : IPagenation<T>  where T : class
    {
        public int PageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public int maxPagesize { get; set; } = 10;

        public async Task<IReadOnlyList<T>> ApplyPageination(IQueryable<T> data)
        {
            var PageSize = this.pageSize > this.maxPagesize?maxPagesize:this.pageSize;
            return await data.Skip((PageNumber - 1) * pageSize).Take(PageSize).ToListAsync(); 
            //(1-1)*3=>0;
        }
    }

   
}
