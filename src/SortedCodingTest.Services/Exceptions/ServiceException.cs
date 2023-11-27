using System.Net;

namespace SortedCodingTest.Services.Exceptions
{
    public class ServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public ServiceException(string? message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}