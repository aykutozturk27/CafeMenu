using AutoMapper;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Mappings.AutoMapper.Profiles
{
    public class ProductPropertyProfile : Profile
    {
        public ProductPropertyProfile()
        {
            CreateMap<List<ProductProperty>, ProductPropertyListDto>()
                .ForMember(x => x.ProductProperties, y => y.MapFrom(z => z.ToList())).ReverseMap();
            CreateMap<ProductProperty, ProductPropertyAddDto>().ReverseMap();
            CreateMap<ProductProperty, ProductPropertyUpdateDto>().ReverseMap();
            CreateMap<ProductProperty, ProductPropertyDeleteDto>().ReverseMap();
        }
    }
}
