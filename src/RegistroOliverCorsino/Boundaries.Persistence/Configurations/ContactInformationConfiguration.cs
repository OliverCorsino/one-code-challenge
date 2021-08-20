using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class ContactInformationConfiguration : IEntityTypeConfiguration<ContactInformation>
    {
        void IEntityTypeConfiguration<ContactInformation>.Configure(EntityTypeBuilder<ContactInformation> builder)
        {
            builder.HasKey(contactInformation => contactInformation.Id);

            builder.Property(contactInformation => contactInformation.Id).UseIdentityColumn(1, 1);
            builder.Property(contactInformation => contactInformation.Description).IsRequired().HasMaxLength(50);
            builder.Property(contactInformation => contactInformation.Status).IsRequired().HasDefaultValue(EntityStatus.Active);

            builder.HasIndex(contactInformation => contactInformation.Description).IsUnique().HasDatabaseName("IDX_CONTACT_INFORMATION_DESCRIPTION");

            builder.HasOne(contactInformation => contactInformation.User)
                .WithMany(user => user.ContactInformation)
                .HasForeignKey(contactInformation => contactInformation.UserId);
        }
    }
}
