using SortedCodingTest.Services.Dto;
using SortedCodingTest.Services.Exceptions;
using SortedCodingTest.Services.Interfaces;
using SortedCodingTest.Services.Mapping;
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

        public async Task<ICollection<RainfallReadingDto>> GetRainfallReadingsAsync(int stationId, int limit)
        {
            var readings = await _client.GetRainfallReadingsAsync(stationId, limit);

            if (!readings.Any())
            {
                throw new ServiceException(ErrorMessages.NoReadingsForStation, HttpStatusCode.NotFound);
            }

            return readings.Select(x => x.ToRainfallReadingDto()).ToList();
        }
    }
}