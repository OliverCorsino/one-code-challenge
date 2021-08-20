using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using System.Reflection;

namespace Boundaries.Persistence
{
    /// <summary>
    /// Represents the session with the database which can be used to query and save instances of your entities to a database.
    /// </summary>
    public sealed class RegistrationDbContext : DbContext
    {
        internal DbSet<User> Users { get; set; }

        internal DbSet<Role> Roles { get; set; }

        internal DbSet<EducationLevel> EducationLevels { get; set; }

        internal DbSet<ContactInformation> ContactInformation { get; set; }

        internal DbSet<ContactInformationType> ContactInformationTypes { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="RegistrationDbContext"/> class.
        /// </summary>
        /// <param name="dbContextOptions">Represents the options that will be used for this context.</param>
        public RegistrationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            const int maxLength = 300;
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(RegistrationDbContext)));

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (!property.GetMaxLength().HasValue)
                {
                    property.AsProperty().Builder.HasMaxLength(maxLength, ConfigurationSource.Convention);
                }

                property.SetColumnType($"varchar({property.GetMaxLength().Value})");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
