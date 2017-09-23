using System;
using Celebrity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Celebrity
{
    public class ProgramStartup
    {
        public ProgramStartup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CelebrityDataContext>(this.ConfigureDataContext);

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<CelebrityDataContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }

        private void ConfigureDataContext(DbContextOptionsBuilder options)
        {
            var connection = this.Configuration.GetConnectionString("Default");

            options.UseSqlite(connection,
                builder => builder.MigrationsAssembly(typeof(CelebrityDataContext).Assembly.FullName));
        }
    }
}