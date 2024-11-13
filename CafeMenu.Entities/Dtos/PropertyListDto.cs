using CafeMenu.Core.Entities;
using CafeMenu.Entities.Concrete;

namespace CafeMenu.Entities.Dtos
{
    public class PropertyListDto : IDto
    {
        public List<Property> Properties { get; set; }
    }
}
