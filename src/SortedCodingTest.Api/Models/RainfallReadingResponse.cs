﻿using SortedCodingTest.App.Dto;

namespace SortedCodingTest.Api.Models
{
    public class RainfallReadingResponse
    {
        public List<RainfallReadingDto> Readings { get; set; }

        public RainfallReadingResponse()
        {
            Readings = new List<RainfallReadingDto>();
        }
    }
}