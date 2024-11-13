using CafeMenu.Core.Entities;

namespace CafeMenu.Entities.Concrete
{
    public class ProductProperty : IEntity
    {
        public int ProductPropertyId { get; set; }
        public int ProductId { get; set; }
        public int PropertyId { get; set; }

        public Product Product { get; set; }
        public Property Property { get; set; }
    }
}
