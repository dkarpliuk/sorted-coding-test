namespace SortedCodingTest.Host.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        public List<ErrorDetail> Detail { get; set; }

        public ErrorResponse()
        {
            Detail = new List<ErrorDetail>();
        }
    }
}