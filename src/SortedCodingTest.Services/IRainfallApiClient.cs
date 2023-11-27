namespace SortedCodingTest.Services
{
    public interface IRainfallApiClient
    {
        Task<ICollection<RainfallApiReading>> GetLatestStationReadingsAsync(int stationId, int limit);
    }
}