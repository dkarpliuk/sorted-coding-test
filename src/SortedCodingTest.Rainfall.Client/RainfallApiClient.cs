using SortedCodingTest.Rainfall.Client.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace SortedCodingTest.Rainfall.Client
{
    public class RainfallApiClient : IRainfallApiClient
    {
        private readonly HttpClient _client;

        public RainfallApiClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ICollection<RainfallApiReading>> GetRainfallReadingsAsync(int stationId, int limit)
        {
            try
            {
                var response = await _client.GetAsync($"id/stations/{stationId}/readings?_sorted&_limit={limit}");

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var result = JsonNode.Parse(content)?["items"]?.Deserialize<List<RainfallApiReading>>()
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