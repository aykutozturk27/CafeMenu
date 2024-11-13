using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int CreatorUserId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public Category Category { get; set; }
        public User User { get; set; }
        public IList<ProductProperty> ProductProperties { get; set; }
    }
}
