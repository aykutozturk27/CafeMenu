using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class CategoryUpdateDto : IDto
    {
        //CreatorUserId, IsDeleted, CreatedDate eklenecek
        public int CategoryId { get; set; }
        public int ParentCategoryId { get; set; }
        public string? CategoryName { get; set; }
    }
}
