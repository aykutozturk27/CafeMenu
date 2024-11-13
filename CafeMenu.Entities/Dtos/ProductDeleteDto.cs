using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class ProductDeleteDto : IDto
    {
        public int ProductId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
