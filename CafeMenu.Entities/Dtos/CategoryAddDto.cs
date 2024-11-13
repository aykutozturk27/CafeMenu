using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class CategoryAddDto : IDto
    {
        public int? ParentCategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
