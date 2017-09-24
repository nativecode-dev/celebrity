namespace Celebrity
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using Core.Extensions;
    using Data;
    using Data.Extensions;
    using Data.Models;
    using Data.Models.Identity;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Nito.AsyncEx;

    internal class Program
    {
        private const string ErrorFileName = "error.txt";

        private static readonly IReadOnlyDictionary<string, Type> SeedDataFiles = new ReadOnlyDictionary<string, Type>(
            new Dictionary<string, Type>
            {
                {"Celebrity.Seeding.Role.json", typeof(Role[])},
                {"Celebrity.Seeding.User.json", typeof(User[])},
                {"Celebrity.Seeding.UserRole.json", typeof(UserRole[])},
                {"Celebrity.Seeding.Organization.json", typeof(Organization[])},
                {"Celebrity.Seeding.OrganizationUser.json", typeof(OrganizationUser[])},
            });

        public static void Main(string[] args)
        {
            AsyncContext.Run(async () => await Program.MainAsync(args).ConfigureAwait(true));
        }

        private static async Task MainAsync(string[] args)
        {
            try
            {
                var host = WebHost.CreateDefaultBuilder(args)
                    .UseStartup<ProgramStartup>()
                    .Build();

                using (var scope = host.Services.CreateScope())
                using (var context = scope.ServiceProvider.GetService<CelebrityDataContext>())
                {
                    if (context.HasMigrations())
                    {
                        await context.Database.MigrateAsync().ConfigureAwait(true);
                        await Program.CreateSeedDataAsync(context).ConfigureAwait(true);
                    }
                }

                await host.RunAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                var filename = Path.Combine(AppContext.BaseDirectory, Program.ErrorFileName);
                var message = ex.ToExceptionString(true);
                await File.WriteAllTextAsync(filename, message).ConfigureAwait(false);
                Console.WriteLine(message);
            }
        }

        private static async Task CreateSeedDataAsync(CelebrityDataContext context)
        {
            var assembly = typeof(Program).Assembly;

            foreach (var kvp in Program.SeedDataFiles)
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