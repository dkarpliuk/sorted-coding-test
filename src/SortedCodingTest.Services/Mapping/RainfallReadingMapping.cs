using SortedCodingTest.Services.Models;

namespace SortedCodingTest.Services.Mapping
{
    public static class RainfallReadingMapping
    {
        public static RainfallReading ToRainfallReading(this RainfallApiReading reading)
        {
            return new RainfallReading
            {
                DateMeasured = reading.DateTime,
                AmountMeasured = reading.Value
            };
        }
    }
}