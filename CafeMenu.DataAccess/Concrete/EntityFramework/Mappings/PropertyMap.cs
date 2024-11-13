using CafeMenu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenu.DataAccess.Concrete.EntityFramework.Mappings
{
    public class PropertyMap : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable(@"Property", @"dbo");

            builder.HasKey(u => u.PropertyId);

            builder.Property(u => u.Key).HasColumnName("Key").HasColumnType("nvarchar(100)");
            builder.Property(u => u.Value).HasColumnName("Value").HasColumnType("nvarchar(100)");
        }
    }
}
