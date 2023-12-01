using Microsoft.AspNetCore.Mvc;
using SortedCodingTest.Api.Models;
using SortedCodingTest.App.Interfaces;
using SortedCodingTest.Host.Models;

namespace SortedCodingTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService ?? throw new ArgumentNullException(nameof(rainfallService));
        }

        [HttpGet]
        [Route("id/{stationId}/readings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<RainfallReadingResponse> GetRainfallReadings([FromRoute, FromQuery] LatestStationReadingsRequest request)
        {
            var readings = await _rainfallService.GetRainfallReadingsAsync(request.StationId, request.Maximum.Value);

            return new RainfallReadingResponse { Readings = readings.ToList() };
        }
    }
}