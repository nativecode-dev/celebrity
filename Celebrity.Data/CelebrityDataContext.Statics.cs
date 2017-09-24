namespace Celebrity.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Entities;
    using Entities.Identity;
    using Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;

    public partial class CelebrityDataContext
    {
        private static readonly IReadOnlyDictionary<string, Type> SeedingResources = new ReadOnlyDictionary<string, Type>(
            new Dictionary<string, Type>
            {
                {"Celebrity.Data.Seeding.Role.json", typeof(Role[])},
                {"Celebrity.Data.Seeding.User.json", typeof(User[])},
                {"Celebrity.Data.Seeding.UserRole.json", typeof(UserRole[])},
                {"Celebrity.Data.Seeding.Organization.json", typeof(Organization[])},
                {"Celebrity.Data.Seeding.OrganizationUser.json", typeof(OrganizationUser[])}
            });

        public static async Task InitializeAsync(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<CelebrityDataContext>())
            {
                if (context.HasMigrations())
                {
                    await context.Database.MigrateAsync().ConfigureAwait(true);
                    await CelebrityDataContext.CreateSeedDataAsync(context).ConfigureAwait(true);
                }
            }
        }

        private static async Task CreateSeedDataAsync(DbContext context)
        {
            var assembly = typeof(CelebrityDataContext).Assembly;

            foreach (var kvp in CelebrityDataContext.SeedingResources)
            {
                var key = kvp.Key;
                var type = kvp.Value;

                using (var stream = assembly.GetManifestResourceStream(key))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = await reader.ReadToEndAsync().ConfigureAwait(true);
                    var records = JsonConvert.DeserializeObject(content, type);

                    context.AddRange((object[]) records);
                }
            }

            await context.SaveChangesAsync().ConfigureAwait(true);
        }
    }
}