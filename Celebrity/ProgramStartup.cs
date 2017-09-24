namespace Celebrity
{
    using System;
    using Data.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Web.Extensions;

    public class ProgramStartup
    {
        public ProgramStartup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCelebrityData(this.Configuration);
            services.AddCelebrityMvc(this.Configuration);
            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCelebrityMvc();
        }
    }
}