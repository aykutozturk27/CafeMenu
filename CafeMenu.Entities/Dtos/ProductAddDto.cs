using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class ProductAddDto : IDto
    {
        public int CategoryId { get; set; }
        public int CreatorUserId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
    }
}
