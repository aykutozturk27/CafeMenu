using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class ProductPropertyUpdateDto : IDto
    {
        public int ProductPropertyId { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
    }
}
