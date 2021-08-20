using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Boundaries.Persistence
{
    /// <summary>
    /// Represents the default db context factory for this application.
    /// </summary>
    public sealed class RegistrationDbContextFactory : IDesignTimeDbContextFactory<RegistrationDbContext>
    {
        private readonly IConfigurationRoot _config;

        /// <summary>
        /// Initializes a new instance of <see cref="RegistrationDbContextFactory"/> class.
        /// </summary>
        public RegistrationDbContextFactory()
        {
            var basePath = AppContext.BaseDirectory;
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        /// <inheritdoc />
        public RegistrationDbContext CreateDbContext(string[] args)
            => Create(_config.GetConnectionString("RegistrationConnectionString"));

        private static RegistrationDbContext Create(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException($"{nameof(connectionString)} is null or empty.", nameof(connectionString));
            }

            var optionsBuilder = new DbContextOptionsBuilder<RegistrationDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new RegistrationDbContext(optionsBuilder.Options);
        }
    }
}
