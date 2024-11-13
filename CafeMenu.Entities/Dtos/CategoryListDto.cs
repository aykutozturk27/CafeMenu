using CafeMenu.Core.Entities;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.Entities.Dtos
{
    public class CategoryListDto : IDto
    {
        public List<Category> Categories { get; set; }
    }
}
