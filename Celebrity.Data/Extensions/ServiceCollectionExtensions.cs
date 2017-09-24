namespace Celebrity.Data.Extensions
{
    using System;
    using Entities.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCelebrityData(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CelebrityDataContext>(options =>
                ServiceCollectionExtensions.ConfigureDataContext(options, configuration));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<CelebrityDataContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 12;
                options.Password.RequiredUniqueChars = 1;

                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Expiration = TimeSpan.FromDays(30);
                options.Cookie.HttpOnly = true;
                options.SlidingExpiration = true;
            });

            return services;
        }

        private static void ConfigureDataContext(DbContextOptionsBuilder options, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("Default");

            options.UseMySql(connection,
                builder => builder.MigrationsAssembly(typeof(CelebrityDataContext).Assembly.FullName));
        }
    }
}