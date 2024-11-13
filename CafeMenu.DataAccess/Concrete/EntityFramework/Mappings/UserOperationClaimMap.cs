using CafeMenu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenu.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserOperationClaimMap : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable(@"UserOperationClaims", @"dbo");

            builder.HasKey(u => u.Id);

            builder.HasOne(uoc => uoc.User).WithMany(uoc => uoc.UserOperationClaims).HasForeignKey(u => u.UserId);
            builder.HasOne(uoc => uoc.OperationClaim).WithMany(uoc => uoc.UserOperationClaims).HasForeignKey(u => u.OperationClaimId);
        }
    }
}
