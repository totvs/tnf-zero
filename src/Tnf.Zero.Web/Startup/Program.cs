using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Tnf.Zero.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("https://*:1010")
                .Build();
    }
}
