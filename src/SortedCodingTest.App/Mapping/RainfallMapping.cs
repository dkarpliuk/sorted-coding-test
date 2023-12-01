using SortedCodingTest.App.Dto;
using SortedCodingTest.Rainfall.Client.Models;

namespace SortedCodingTest.App.Mapping
{
    public static class RainfallMapping
    {
        public static RainfallReadingDto ToRainfallReadingDto(this RainfallApiReading reading)
        {
            return new RainfallReadingDto
            {
                DateMeasured = reading.DateTime,
                AmountMeasured = reading.Value
            };
        }
    }
}