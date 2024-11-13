using CafeMenu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenu.DataAccess.Concrete.EntityFramework.Mappings
{
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable(@"OperationClaim", @"dbo");

            builder.HasKey(u => u.Id);

            builder.Property(a => a.Name).HasColumnName("Name").HasColumnType("nvarchar(100)");
        }
    }
}
