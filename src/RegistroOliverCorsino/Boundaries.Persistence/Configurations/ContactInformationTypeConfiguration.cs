using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class ContactInformationTypeConfiguration : IEntityTypeConfiguration<ContactInformationType>
    {
        void IEntityTypeConfiguration<ContactInformationType>.Configure(EntityTypeBuilder<ContactInformationType> builder)
        {
            builder.HasKey(contactInformationType => contactInformationType.Id);

            builder.Property(contactInformationType => contactInformationType.Id).UseIdentityColumn(1, 1);
            builder.Property(contactInformationType => contactInformationType.Description).IsRequired().HasMaxLength(50);
            builder.Property(contactInformationType => contactInformationType.Status).IsRequired().HasDefaultValue(EntityStatus.Active);

            builder.HasIndex(contactInformationType => contactInformationType.Description).IsUnique().HasDatabaseName("IDX_CONTACT_INFORMATION_TYPE_DESCRIPTION");

            builder.HasData(
                new { Id = 1, Description = "Correo electrónico" },
                new { Id = 2, Description = "Teléfono móvil" },
                new { Id = 3, Description = "Teléfono fijo" }
            );
        }
    }
}
