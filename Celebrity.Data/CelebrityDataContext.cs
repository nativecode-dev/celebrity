namespace Celebrity.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Identity;
    using Microsoft.EntityFrameworkCore;

    public partial class CelebrityDataContext : DbContext
    {
        public CelebrityDataContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Organization> Organizations { get; set; }

        public virtual DbSet<OrganizationUser> OrganizationUsers { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<WebHook> WebHooks { get; set; }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.UpdateAuditFields();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = new CancellationToken())
        {
            this.UpdateAuditFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateAuditFields()
        {
            var entries = from entry in this.ChangeTracker.Entries()
                let type = entry.Entity.GetType()
                where type.GetInterfaces().Any(i => i == typeof(IEntity))
                select entry;

            foreach (var entry in entries)
            {
                var model = (IEntity) entry.Entity;

                if (model is IEntity<Guid> keymaster)
                {
                    if (keymaster.Id == default(Guid))
                    {
                        keymaster.Id = Guid.NewGuid();
                    }
                }

                model.DateModified = DateTimeOffset.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    model.DateCreated = DateTimeOffset.UtcNow;
                }
            }
        }
    }
}