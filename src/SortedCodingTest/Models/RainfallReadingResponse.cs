﻿using SortedCodingTest.Services.Dto;

namespace SortedCodingTest.Models
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