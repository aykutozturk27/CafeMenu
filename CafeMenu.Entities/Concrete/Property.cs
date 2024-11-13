using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Concrete
{
    public class Property : IEntity
    {
        public int PropertyId { get; set; }
        public string? Key { get; set; }
        public string? Value { get; set; }

        public IList<ProductProperty> ProductProperties { get; set; }
    }
}
