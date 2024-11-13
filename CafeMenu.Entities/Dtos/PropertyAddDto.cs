using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Dtos
{
    public class PropertyAddDto : IDto
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
    }
}
