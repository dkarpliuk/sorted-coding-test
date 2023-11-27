using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace SortedCodingTest.Services
{
    public class RainfallApiClient : IRainfallApiClient
    {
        private const int MaxStationReadingsLimit = 10000;

        private readonly RainfallApiClientOptions _options;

        public RainfallApiClient(IOptions<RainfallApiClientOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(_options.BaseUrl))
            {
                throw new InvalidOperationException($"{nameof(_options.BaseUrl)} not specified");
            }
        }

        public async Task<ICollection<RainfallApiReading>> GetLatestStationReadingsAsync(int stationId, int limit)
        {
            if (limit > MaxStationReadingsLimit)
            {
                throw new RainfallApiClientException($"Station readings limit exceeded, maximum is {MaxStationReadingsLimit}");
            }

            using var client = new HttpClient { BaseAddress = new Uri(_options.BaseUrl) };

            try
            {
                var response = await client.GetAsync($"/id/stations/{stationId}/readings?_sorted&_limit={limit}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JObject
                    .Parse(content)
                    .SelectToken("items")?
                    .ToObject<List<RainfallApiReading>>()
                    ?? throw new RainfallApiClientException("Could not parse the response");

                return result;
            }
            catch (RainfallApiClientException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new RainfallApiClientException("Could not retrieve rainfall readings", ex);
            }
        }
    }
}