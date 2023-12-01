using System.Net;

namespace SortedCodingTest.App.Exceptions
{
    public class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public AppException(string? message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}