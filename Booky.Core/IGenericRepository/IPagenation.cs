using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Core.IGenericRepository
{
    public interface IPagenation<T>     where T : class
    {
        public int PageNumber { get; set; }
        public int pageSize { get; set; }
        public int maxPagesize { get; set; }
     Task<IReadOnlyList<T> >ApplyPageination(IQueryable<T> data);
    }
}
