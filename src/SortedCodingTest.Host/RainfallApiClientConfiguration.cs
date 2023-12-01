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
            
            services.AddHttpClient<IRainfallApiClient, RainfallApiClient>(client => client.BaseAddress = new Uri(options.BaseUrl))
                .SetHandlerLifetime(TimeSpan.FromSeconds(options.TimeoutSeconds));
            
            services.AddTransient<IRainfallApiClient, RainfallApiClient>();

            return services;
        }
    }
}