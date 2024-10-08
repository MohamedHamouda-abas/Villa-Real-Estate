using AutoMapper;
using VailaPlace.Models;
using VailaPlace.Models.Dto;

namespace VailaPlace.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Vaila, VailaDto>().ReverseMap();
            CreateMap<Vaila, VailaCraeteDto>().ReverseMap();
            CreateMap<Vaila, VailaUpdteDto>().ReverseMap();

            CreateMap<VailaNumber, VailaNumberDto>().ReverseMap();
            CreateMap<VailaNumber, VailaNumberCreateDto>().ReverseMap();
            CreateMap<VailaNumber, VailaNumberUpdateDto>().ReverseMap();

        }
    }
}
