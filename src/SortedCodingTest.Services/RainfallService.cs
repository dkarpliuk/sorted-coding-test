using SortedCodingTest.Services.Exceptions;
using SortedCodingTest.Services.Interfaces;
using SortedCodingTest.Services.Mapping;
using SortedCodingTest.Services.Models;
using System.Net;

namespace SortedCodingTest.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly IRainfallApiClient _client;

        public RainfallService(IRainfallApiClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<RainfallReadingResponse> GetLatestStationReadingsAsync(int stationId, int limit)
        {
            var readings = await _client.GetLatestStationReadingsAsync(stationId, limit);

            if (!readings.Any())
            {
                throw new ServiceException(ErrorMessages.NoReadingsForStation, HttpStatusCode.NotFound);
            }

            return new RainfallReadingResponse
            {
                Readings = readings.Select(x => x.ToRainfallReading()).ToList()
            };
        }
    }
}