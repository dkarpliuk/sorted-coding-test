using SortedCodingTest.App.Dto;
using SortedCodingTest.App.Exceptions;
using SortedCodingTest.App.Interfaces;
using SortedCodingTest.App.Mapping;
using SortedCodingTest.Rainfall.Client;
using System.Net;

namespace SortedCodingTest.App
{
    public class RainfallService : IRainfallService
    {
        private readonly IRainfallApiClient _client;

        public RainfallService(IRainfallApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<ICollection<RainfallReadingDto>> GetRainfallReadingsAsync(int stationId, int limit)
        {
            var readings = await _client.GetRainfallReadingsAsync(stationId, limit);

            if (!readings.Any())
            {
                throw new AppException(ErrorMessages.NoReadingsForStation, HttpStatusCode.NotFound);
            }

            return readings.Select(x => x.ToRainfallReadingDto()).ToList();
        }
    }
}