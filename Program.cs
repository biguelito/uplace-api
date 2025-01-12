using UplaceApi;

namespace CRUDApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var url = Environment.GetEnvironmentVariable("API_COMMON") ?? "http://localhost:5000";
                    webBuilder
                    .UseUrls(url)
                    .UseStartup<Startup>();
                });
    }
}
