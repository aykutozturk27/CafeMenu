using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class PropertyUpdateDto : IDto
    {
        public int PropertyId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
