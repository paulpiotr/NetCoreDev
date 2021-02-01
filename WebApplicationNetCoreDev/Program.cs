using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebApplicationNetCoreDev
{
    public class Program
    {
        private static readonly CancellationTokenSource _cancelTokenSource = new CancellationTokenSource();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().RunAsync(_cancelTokenSource.Token).GetAwaiter().GetResult();
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
            _cancelTokenSource.Cancel();
        }
    }
}
