using Booky.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Core.IGenericRepository
{
    public interface IestateRepoistory : IgenericRepoistory<Estate>
    {
        public Task<IReadOnlyList<Estate>> getestateByid(int? Typeid);
        public Task<IReadOnlyList<Estate>> Getestatebytypenamename(string? typename);
    }
}
