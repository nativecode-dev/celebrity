namespace Celebrity.Data
{
    using System;
    using System.IO;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class CelebrityDataContextFactory : IDesignTimeDbContextFactory<CelebrityDataContext>
    {
        public CelebrityDataContextFactory()
        {
            var builder = new ConfigurationBuilder();
            var settings = Path.Combine(AppContext.BaseDirectory, "appSettings.json");
            builder.AddJsonFile(settings);

            this.Configuration = builder.Build();
        }

        public CelebrityDataContextFactory(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        public CelebrityDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CelebrityDataContext>();
            builder.UseMySql(this.Configuration.GetConnectionString("Default"));

            return new CelebrityDataContext(builder.Options);
        }
    }
}