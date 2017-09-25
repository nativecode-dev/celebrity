namespace Celebrity
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Core.Extensions;
    using Data;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Nito.AsyncEx;

    internal class Program
    {
        private const string ErrorFileName = "error.txt";

        public static void Main(string[] args)
        {
            AsyncContext.Run(async () => await Program.MainAsync(args).ConfigureAwait(true));
        }

        private static async Task MainAsync(string[] args)
        {
            try
            {
                var builder = WebHost
                    .CreateDefaultBuilder(args)
                    .CaptureStartupErrors(true)
                    .UseApplicationInsights()
                    .UseStartup<ProgramStartup>()
                    .UseUrls("http://*:5000");

                var host = builder.Build();

                await CelebrityDataContext
                    .InitializeAsync(host)
                    .ConfigureAwait(true);

                await host.RunAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                var filename = Path.Combine(AppContext.BaseDirectory, Program.ErrorFileName);
                var message = ex.ToExceptionString(true);
                var task = File.WriteAllTextAsync(filename, message).ConfigureAwait(false);

                Console.WriteLine(message);

                await task;
            }
        }
    }
}