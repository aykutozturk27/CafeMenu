using CafeMenu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenu.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(@"Category", @"dbo");

            builder.HasKey(u => u.CategoryId);

            builder.Property(u => u.ParentCategoryId).HasColumnName("ParentCategoryId").HasColumnType("int");

            builder.Property(u => u.CategoryName).HasColumnName("CategoryName").HasColumnType("nvarchar(100)");
            builder.Property(u => u.IsDeleted).HasColumnName("IsDeleted").HasColumnType("bit");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime");

            builder.HasOne(x => x.User).WithMany(x => x.Categories).HasForeignKey(x => x.CreatorUserId).IsRequired(false);
        }
    }
}
