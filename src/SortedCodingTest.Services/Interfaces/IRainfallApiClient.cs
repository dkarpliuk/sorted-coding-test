using SortedCodingTest.Services.Models;

namespace SortedCodingTest.Services.Interfaces
{
    public interface IRainfallApiClient
    {
        Task<ICollection<RainfallApiReading>> GetLatestStationReadingsAsync(int stationId, int limit);
    }
}