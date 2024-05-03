
using AutoMapper;
using Booky.API.DTO;
using Booky.Core.Models;

namespace Booky.API.MappingProfile
{
    public class EstateProfile:Profile
    {
        public EstateProfile()
        {
            CreateMap<Estate, EstateDto>().ForMember(x => x.EstateType, o => o.MapFrom(x => x.EstateType.TypeName));
            CreateMap<EstateDto, Estate>().ReverseMap();

        }
    }
}
