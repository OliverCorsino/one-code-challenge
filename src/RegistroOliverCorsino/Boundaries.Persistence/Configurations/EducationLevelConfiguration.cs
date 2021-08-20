using System.Collections.Generic;
using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boundaries.Persistence.Configurations
{
    internal sealed class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel>
    {
        void IEntityTypeConfiguration<EducationLevel>.Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            builder.HasKey(educationLevel => educationLevel.Id);

            builder.Property(educationLevel => educationLevel.Id).UseIdentityColumn(1, 1);
            builder.Property(educationLevel => educationLevel.Description).IsRequired().HasMaxLength(50);
            builder.Property(educationLevel => educationLevel.Status).IsRequired().HasDefaultValue(EntityStatus.Active);

            builder.HasIndex(educationLevel => educationLevel.Description).IsUnique().HasDatabaseName("IDX_EDUCATION_LEVEL_DESCRIPTION");

            builder.HasData(
                new { Id = 1, Description = "Bachiller" },
                new { Id = 2, Description = "Universitaria" },
                new { Id = 3, Description = "Postgrado" }
                );
        }
    }
}
