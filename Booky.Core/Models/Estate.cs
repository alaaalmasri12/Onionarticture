using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booky.Core.Models
{
    public class Estate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Rate { get; set; }
        public int sqft { get; set; }
        public string? ImageURL { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("EstateType")]
        public  int EstateTypeId { get; set; }

        public EstateType? EstateType { get; set; }

    }
}
