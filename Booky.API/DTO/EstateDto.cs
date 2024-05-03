using Booky.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booky.API.DTO
{
    public class EstateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int Rate { get; set; }
        public int sqft { get; set; }
        public string? ImageURL { get; set; }
        public int EstateTypeId { get; set; }

        public string? EstateType { get; set; }
    }
}
