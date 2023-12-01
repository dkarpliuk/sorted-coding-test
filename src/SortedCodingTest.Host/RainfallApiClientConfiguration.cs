using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SortedCodingTest.Rainfall.Client
{
    public static class RainfallApiClientConfiguration
    {
        public static IServiceCollection AddRainfallApiClient(this IServiceCollection services, IConfiguration config)
        {
            var options = config.GetValue<RainfallApiClientOptions>(nameof(RainfallApiClientOptions)) ?? throw new InvalidOperationException();
            
            services.AddHttpClient<IRainfallApiClient, RainfallApiClient>(client => client.BaseAddress = new Uri(options.BaseUrl))
                .SetHandlerLifetime(TimeSpan.FromMilliseconds(options.TimeoutMs));
            
            services.AddTransient<IRainfallApiClient, RainfallApiClient>();

            return services;
        }
    }
}