namespace SortedCodingTest.Services
{
    public class RainfallApiClientException : Exception
    {
        public RainfallApiClientException(string? message) : base(message)
        {
        }

        public RainfallApiClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}