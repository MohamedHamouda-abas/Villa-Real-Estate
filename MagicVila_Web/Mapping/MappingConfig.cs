using AutoMapper;
using MagicVila_Web.Models;
using MagicVila_Web.Models.Dto;

namespace MagicVila_Web.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
          
            CreateMap<VailaDto, VailaCraeteDto>().ReverseMap();
            CreateMap<VailaDto, VailaUpdteDto>().ReverseMap();

         
            CreateMap<VailaNumberDto, VailaNumberCreateDto>().ReverseMap();
            CreateMap<VailaNumberDto, VailaNumberUpdateDto>().ReverseMap();

        }
    }
}
