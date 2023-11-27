using SortedCodingTest.Services.Models;

namespace SortedCodingTest.Services.Interfaces
{
    public interface IRainfallService
    {
        Task<RainfallReadingResponse> GetLatestStationReadingsAsync(int stationId, int limit);
    }
}