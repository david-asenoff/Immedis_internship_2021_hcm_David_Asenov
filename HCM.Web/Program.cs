using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HCM.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseMetricsWebTracking()
                //Use Prometheus text formatter
                //.UseMetrics(options =>
                //{
                //    options.EndpointOptions = endpointsOptions =>
                //    {
                //        endpointsOptions.MetricsTextEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                //        endpointsOptions.MetricsEndpointOutputFormatter = new MetricsPrometheusTextOutputFormatter();
                //        endpointsOptions.EnvironmentInfoEndpointEnabled = false;
                //    };
                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
