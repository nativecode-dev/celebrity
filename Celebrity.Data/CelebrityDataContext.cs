namespace Celebrity.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CelebrityDataContext : DbContext
    {
        public CelebrityDataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<IdentityRole> IdentityRoles { get; set; }

        public virtual DbSet<IdentityUser> IdentityUsers { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<WebHook> WebHooks { get; set; }
    }
}