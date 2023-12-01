using SortedCodingTest.App.Models;

namespace SortedCodingTest.App.Interfaces
{
    public interface IRainfallApiClient
    {
        Task<ICollection<RainfallReading>> GetRainfallReadingsAsync(int stationId, int limit);
    }
}