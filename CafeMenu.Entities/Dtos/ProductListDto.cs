using CafeMenu.Core.Entities;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.Entities.Dtos
{
    public class ProductListDto : IDto
    {
        public List<Product> Products { get; set; }
    }
}
