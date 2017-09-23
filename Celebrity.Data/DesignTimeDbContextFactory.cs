using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Celebrity.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CelebrityDataContext>
    {
        public CelebrityDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CelebrityDataContext>();
            builder.UseSqlite("Data Source=celebrity.db");

            return new CelebrityDataContext(builder.Options);
        }
    }
}