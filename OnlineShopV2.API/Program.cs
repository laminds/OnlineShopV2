

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using OnlineShopV2.API;

namespace Kiosk.API
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
           });
    
    }
}