using AutoMapper;
using CafeMenu.Entities.Concrete;
using CafeMenu.Entities.Dtos;

namespace CafeMenu.Business.Mappings.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<List<Category>, CategoryListDto>()
                .ForMember(x => x.Categories, y => y.MapFrom(z => z.ToList())).ReverseMap();
            CreateMap<Category, CategoryAddDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryDeleteDto>().ReverseMap();
        }
    }
}
