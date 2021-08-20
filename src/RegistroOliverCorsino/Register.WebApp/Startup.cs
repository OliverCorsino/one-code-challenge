using Boundaries.Persistence;
using Boundaries.Persistence.Repositories;
using Core.Boundaries.Persistence;
using Core.Rules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApp
{
    /// <summary>
    /// Represents the startup configuration class.
    /// </summary>
    public sealed class Startup
    {
        /// <summary>
        /// Initializes a new instance for WebApp.Api.Startup class.
        /// </summary>
        /// <param name="configuration">Represents an <see cref="IConfiguration"/> implementation.</param>
        public Startup(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        /// Represents a <see cref="IConfiguration"/> property.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<RegistrationDbContext>((options) =>
                options.UseSqlServer(Configuration.GetConnectionString("RegistrationConnectionString"),
                    (sqlServerDbContextOptionsBuilder) => sqlServerDbContextOptionsBuilder.MigrationsAssembly("Boundaries.Persistence")));

            AddRepositoriesScoped(services);
            
            AddRulesScoped(services);
        }

        private void AddRepositoriesScoped(IServiceCollection services) => services.AddScoped<IUserRepository, UserRepository>();

        private void AddRulesScoped(IServiceCollection services) => services.AddScoped<UserRules>();

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
