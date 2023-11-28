using SortedCodingTest.Services.Models;

namespace SortedCodingTest.Services.Interfaces
{
    public interface IRainfallApiClient
    {
        Task<ICollection<RainfallReading>> GetRainfallReadingsAsync(int stationId, int limit);
    }
}