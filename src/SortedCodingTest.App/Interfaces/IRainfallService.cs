using SortedCodingTest.App.Dto;

namespace SortedCodingTest.App.Interfaces
{
    public interface IRainfallService
    {
        Task<ICollection<RainfallReadingDto>> GetRainfallReadingsAsync(int stationId, int limit);
    }
}