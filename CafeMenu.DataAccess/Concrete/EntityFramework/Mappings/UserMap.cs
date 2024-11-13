using CafeMenu.Core.Entities;
using CafeMenu.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMenu.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(@"User", @"dbo");

            builder.HasKey(u => u.UserId);

            builder.Property(a => a.Name).HasColumnName("Name").HasColumnType("nvarchar(100)");
            builder.Property(a => a.Surname).HasColumnName("Surname").HasColumnType("nvarchar(100)");
            builder.Property(a => a.Username).HasColumnName("Username").HasColumnType("nvarchar(100)");
            builder.Property(a => a.PasswordHash).HasColumnName("PasswordHash").HasColumnType("varbinary(500)");
            builder.Property(a => a.PasswordSalt).HasColumnName("PasswordSalt").HasColumnType("varbinary(500)");
            builder.Property(a => a.Status).HasColumnName("Status").HasColumnType("bit");
        }
    }
}
