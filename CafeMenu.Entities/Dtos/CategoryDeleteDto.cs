using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class CategoryDeleteDto : IDto
    {
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
