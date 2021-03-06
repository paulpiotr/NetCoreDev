#region using

using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

#endregion

namespace WebApplicationNetCoreDev
{
    public class Program
    {
        private static readonly CancellationTokenSource CancelTokenSource = new();

        public static void Main(string[] args) => CreateHostBuilder(args).Build().RunAsync(CancelTokenSource.Token)
            .GetAwaiter().GetResult();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        //    .ConfigureServices(services =>
        //{
        //    services.AddHostedService<FileSystemWatcherInvoicesWorker>();
        //});

        public static void Shutdown() => CancelTokenSource.Cancel();
    }
}
