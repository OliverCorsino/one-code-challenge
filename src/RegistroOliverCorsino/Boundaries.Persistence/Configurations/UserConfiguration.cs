using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id).UseIdentityColumn(1, 1);
            builder.Property(user => user.Name).IsRequired().HasMaxLength(100);
            builder.Property(user => user.LastName).IsRequired().HasMaxLength(100);
            builder.Property(user => user.IdentificationNumber).IsRequired().HasMaxLength(13);
            builder.Property(user => user.DateOfBirth).IsRequired();
            builder.Property(user => user.RegistrationDate).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.HasIndex(user => user.IdentificationNumber).IsUnique().HasDatabaseName("IDX_USER_IDENTIFICATION_NUMBER");
        }
    }
}
