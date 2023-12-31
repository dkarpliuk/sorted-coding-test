﻿namespace SortedCodingTest.Rainfall.Client
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