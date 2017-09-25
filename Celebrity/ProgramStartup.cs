namespace Celebrity
{
    using System;
    using System.Collections.Generic;
    using Data.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Web.Extensions;
    using Webpack;

    public class ProgramStartup
    {
        public ProgramStartup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services
                .AddCelebrityData(this.Configuration)
                .AddCelebrityMvc(this.Configuration)
                .AddWebpack()
                .BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCelebrityMvc();
            app.UseWebpack(ProgramStartup.CreateWebpack(env));
        }

        private static WebpackOptions CreateWebpack(IHostingEnvironment env)
        {
            var options = new WebpackOptions("Content/client/Startup.ts")
            {
                EnableES2015 = true,
                StylesTypes = new List<StylesType>
                {
                    StylesType.Css,
                    StylesType.Less,
                    StylesType.Sass
                }
            };

            if (env.IsDevelopment())
            {
                options.DevServerOptions = new WebpackDevServerOptions(port: 5000);
                options.EnableHotLoading = true;
            }

            return options;
        }
    }
}