using CafeMenu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenu.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductPropertyMap : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.ToTable(@"ProductProperty", @"dbo");

            builder.HasKey(u => u.ProductPropertyId);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductProperties).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Property).WithMany(x => x.ProductProperties).HasForeignKey(x => x.PropertyId);
        }
    }
}
