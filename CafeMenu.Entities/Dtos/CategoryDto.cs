using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class CategoryDto : IDto
    {
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
