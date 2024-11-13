using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class ProductUpdateDto : IDto
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int CreatorUserId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
    }
}
