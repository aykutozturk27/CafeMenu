using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class ProductPropertyAddDto : IDto
    {
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
    }
}
