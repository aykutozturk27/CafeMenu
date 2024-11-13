using AutoMapper;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Mappings.AutoMapper.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<List<Product>, ProductListDto>()
                .ForMember(x => x.Products, y => y.MapFrom(z => z.ToList())).ReverseMap();
            CreateMap<Product, ProductAddDto>().ReverseMap();
            CreateMap<Product, ProductUpdateDto>().ReverseMap();
            CreateMap<Product, ProductDeleteDto>().ReverseMap();
        }
    }
}
