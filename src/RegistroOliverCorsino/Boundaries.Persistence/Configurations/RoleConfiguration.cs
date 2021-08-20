using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        void IEntityTypeConfiguration<Role>.Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id);

            builder.Property(role => role.Id).UseIdentityColumn(1, 1);
            builder.Property(role => role.Description).IsRequired().HasMaxLength(50);
            builder.Property(role => role.Status).IsRequired().HasDefaultValue(EntityStatus.Active);

            builder.HasIndex(role => role.Description).IsUnique().HasDatabaseName("IDX_ROLE_DESCRIPTION");

            builder.HasData(
                new { Id = 1, Description = "No califica" },
                new { Id = 2, Description = "Empadronador(a)" },
                new { Id = 3, Description = "Supervisor(a)" },
                new { Id = 4, Description = "Coordinador(a)" }
            );
        }
    }
}
