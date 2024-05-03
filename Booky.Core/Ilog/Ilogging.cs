using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Core.Ilog
{
    public interface Ilogging
    {
        public void Log(string message,string type);
    }
}
