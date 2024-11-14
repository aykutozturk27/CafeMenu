using CafeMenu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenu.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(@"Product", @"dbo");

            builder.HasKey(u => u.ProductId);

            builder.Property(u => u.ProductName).HasColumnName("ProductName").HasColumnType("nvarchar(100)");
            builder.Property(u => u.Price).HasColumnName("Price").HasColumnType("decimal(18,2)");
            builder.Property(u => u.ImagePath).HasColumnName("ImagePath");//?
            builder.Property(u => u.IsDeleted).HasColumnName("IsDeleted").HasColumnType("bit");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");

            builder.HasOne(x => x.Category).WithMany(y => y.Products).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.User).WithMany(x => x.Products).HasForeignKey(x => x.CreatorUserId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }
    }
}
