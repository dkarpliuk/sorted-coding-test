using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SortedCodingTest.App.Exceptions;
using SortedCodingTest.App.Interfaces;
using SortedCodingTest.App.Models;

namespace SortedCodingTest.App
{
    public class RainfallApiClient : IRainfallApiClient
    {
        private readonly RainfallApiClientOptions _options;

        public RainfallApiClient(IOptions<RainfallApiClientOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(_options.BaseUrl))
            {
                throw new InvalidOperationException($"{nameof(_options.BaseUrl)} not specified");
            }
        }

        public async Task<ICollection<RainfallReading>> GetRainfallReadingsAsync(int stationId, int limit)
        {
            using var client = new HttpClient { BaseAddress = new Uri(_options.BaseUrl) };

            try
            {
                var response = await client.GetAsync($"id/stations/{stationId}/readings?_sorted&_limit={limit}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JObject
                    .Parse(content)
                    .SelectToken("items")?
                    .ToObject<List<RainfallReading>>()
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