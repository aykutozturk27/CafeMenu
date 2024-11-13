using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryName; //ana kategoriyi göstermek için eklendi.
        public int CreatorUserId { get; set; }
        public string? CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
        public IList<Product> Products { get; set; }
    }
}
