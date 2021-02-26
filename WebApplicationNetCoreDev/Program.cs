using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApplicationNetCoreDev
{
    public class Program
    {
        private static readonly CancellationTokenSource CancelTokenSource = new();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().RunAsync(CancelTokenSource.Token).GetAwaiter().GetResult();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }

        public static void Shutdown()
        {
            CancelTokenSource.Cancel();
        }
    }
}
