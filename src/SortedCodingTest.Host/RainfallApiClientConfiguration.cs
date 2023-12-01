using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SortedCodingTest.Host.ConfigurationModels;

namespace SortedCodingTest.Rainfall.Client
{
    public static class RainfallApiClientConfiguration
    {
        public static IServiceCollection AddRainfallApiClient(this IServiceCollection services, IConfiguration config)
        {
            var options = config.GetSection(nameof(RainfallApiClientOptions)).Get<RainfallApiClientOptions>() ?? throw new InvalidOperationException();

            services.AddTransient<IRainfallApiClient, RainfallApiClient>();

            services.AddHttpClient<IRainfallApiClient, RainfallApiClient>(client =>
            {
                client.BaseAddress = new Uri(options.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            });
            
            return services;
        }
    }
}