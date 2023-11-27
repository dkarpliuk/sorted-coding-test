namespace SortedCodingTest.Services.Models
{
    public class RainfallReadingResponse
    {
        public List<RainfallReading> Readings { get; set; }

        public RainfallReadingResponse()
        {
            Readings = new List<RainfallReading>();
        }
    }
}