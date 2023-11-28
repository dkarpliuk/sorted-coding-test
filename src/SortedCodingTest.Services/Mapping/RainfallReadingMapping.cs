using SortedCodingTest.Services.Dto;
using SortedCodingTest.Services.Models;

namespace SortedCodingTest.Services.Mapping
{
    public static class RainfallReadingMapping
    {
        public static RainfallReadingDto ToRainfallReadingDto(this RainfallReading reading)
        {
            return new RainfallReadingDto
            {
                DateMeasured = reading.DateTime,
                AmountMeasured = reading.Value
            };
        }
    }
}