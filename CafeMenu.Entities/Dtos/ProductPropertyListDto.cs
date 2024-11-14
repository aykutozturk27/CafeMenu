using CafeMenu.Core.Entities;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.Entities.Dtos
{
    public class ProductPropertyListDto : IDto
    {
        public List<ProductProperty> ProductProperties { get; set; }
    }
}
