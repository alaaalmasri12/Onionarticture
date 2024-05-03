using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Core.IGenericRepository
{
    public interface IunitofWork
    {
        public IestateRepoistory estateRepoistory { get; set; }
        public Task<int> SaveAsync();
    }
}
