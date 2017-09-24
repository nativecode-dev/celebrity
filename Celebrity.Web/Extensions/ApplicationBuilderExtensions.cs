namespace Celebrity.Web.Extensions
{
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCelebrityMvc(this IApplicationBuilder builder)
        {
            builder.UseAuthentication();
            builder.UseMvcWithDefaultRoute();
            builder.UseStaticFiles();

            return builder;
        }
    }
}