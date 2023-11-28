using SortedCodingTest.Services.Dto;

namespace SortedCodingTest.Services.Interfaces
{
    public interface IRainfallService
    {
        Task<ICollection<RainfallReadingDto>> GetRainfallReadingsAsync(int stationId, int limit);
    }
}