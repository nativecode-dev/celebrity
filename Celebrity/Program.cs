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
    using Data.Models;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Nito.AsyncEx;

    internal class Program
    {
        private const string ErrorFileName = "error.txt";

        private static readonly IReadOnlyDictionary<string, Type> SeedDataFiles = new ReadOnlyDictionary<string, Type>(
            new Dictionary<string, Type>
            {
                {"Celebrity.Seeding.Organization.json", typeof(List<Organization>)}
            });

        public static void Main(string[] args)
        {
            AsyncContext.Run(async () => await Program.MainAsync(args).ConfigureAwait(false));
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
                    var created = await context.Database.EnsureCreatedAsync().ConfigureAwait(false);

                    if (created)
                    {
                        await Program.CreateSeedData(context).ConfigureAwait(false);
                    }
                }

                await host.RunAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var filename = Path.Combine(AppContext.BaseDirectory, Program.ErrorFileName);
                await File.WriteAllTextAsync(filename, ex.ToExceptionString()).ConfigureAwait(false);
            }
        }

        private static async Task CreateSeedData(CelebrityDataContext context)
        {
            var assembly = typeof(Program).Assembly;

            foreach (var kvp in Program.SeedDataFiles)
            {
                var key = kvp.Key;
                var type = kvp.Value;

                using (var stream = assembly.GetManifestResourceStream(key))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var content = await reader.ReadToEndAsync().ConfigureAwait(false);
                    var records = JsonConvert.DeserializeObject(content, type);

                    context.AddRange(records);
                    await context.SaveChangesAsync().ConfigureAwait(true);
                }
            }
        }
    }
}