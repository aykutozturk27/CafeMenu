using AutoMapper;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Mappings.AutoMapper.Profiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<List<Property>, PropertyListDto>()
                .ForMember(x => x.Properties, y => y.MapFrom(z => z.ToList())).ReverseMap();
            CreateMap<Property, PropertyAddDto>().ReverseMap();
            CreateMap<Property, PropertyUpdateDto>().ReverseMap();
            CreateMap<Property, PropertyDeleteDto>().ReverseMap();
        }
    }
}
