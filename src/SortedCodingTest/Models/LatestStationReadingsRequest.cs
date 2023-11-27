using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SortedCodingTest.Models
{
    public class LatestStationReadingsRequest
    {
        [FromRoute(Name = "stationId")]
        [Range(0, int.MaxValue, ErrorMessage = "Station Id can not be negative")]
        public int StationId { get; set; }

        [FromQuery]
        public int Minimum { get; set; }

        [FromQuery]
        [Range(0, 10000, ErrorMessage = $"Maximum value must be between 0 and 10000")]
        public int Maximum { get; set; }
    }
}