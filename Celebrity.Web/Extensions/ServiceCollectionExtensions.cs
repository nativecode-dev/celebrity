namespace Celebrity.Web.Extensions
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Authorization;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Options;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCelebrityMvc(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddOptions();
            services.Configure<Global>(configuration.GetSection(nameof(Global)));

            return services;
        }
    }
}