using SortedCodingTest.Rainfall.Client.Models;

namespace SortedCodingTest.Rainfall.Client
{
    public interface IRainfallApiClient
    {
        Task<ICollection<RainfallApiReading>> GetRainfallReadingsAsync(int stationId, int limit);
    }
}