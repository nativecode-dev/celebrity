namespace Celebrity
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Data;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Nito.AsyncEx;

    internal class Program
    {
        private const string ErrorFileName = "error.txt";

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

                using (var context = host.Services.GetService<CelebrityDataContext>())
                {
                    var created = await context.Database.EnsureCreatedAsync().ConfigureAwait(false);

                    if (created == false)
                    {
                        await context.Database.MigrateAsync().ConfigureAwait(false);
                    }
                }

                await host.RunAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Program.ErrorFileName);
                await File.WriteAllTextAsync(filename, ex.ToString()).ConfigureAwait(false);
            }
        }
    }
}