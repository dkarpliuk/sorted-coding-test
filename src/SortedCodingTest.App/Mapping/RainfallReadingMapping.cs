using SortedCodingTest.App.Dto;
using SortedCodingTest.App.Models;

namespace SortedCodingTest.App.Mapping
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