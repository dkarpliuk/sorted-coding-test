namespace SortedCodingTest.Rainfall.Client
{
    public interface IRainfallApiClient
    {
        Task<ICollection<RainfallReading>> GetRainfallReadingsAsync(int stationId, int limit);
    }
}