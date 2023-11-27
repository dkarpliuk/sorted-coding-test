using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SortedCodingTest.Models
{
    public class LatestStationReadingsRequest
    {
        private const int MaxStationReadingsLimit = 10000;

        [FromRoute]
        public int StationId { get; set; }

        [FromQuery]
        public int Minimum { get; set; }

        [FromQuery]
        [Range(0, MaxStationReadingsLimit)]
        public int Maximum { get; set; }
    }
}