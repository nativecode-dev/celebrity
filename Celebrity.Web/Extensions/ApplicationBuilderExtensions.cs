namespace Celebrity.Web.Extensions
{
    using Microsoft.AspNetCore.Builder;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCelebrityMvc(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

            return app;
        }
    }
}