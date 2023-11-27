using Microsoft.AspNetCore.Mvc;
using SortedCodingTest.Models;
using SortedCodingTest.Services.Interfaces;
using SortedCodingTest.Services.Models;

namespace SortedCodingTest.Controllers
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

        [HttpGet(Name = "GetLatestStationReadings")]
        [Route("id/{stationId}/readings")]
        public async Task<RainfallReadingResponse> GetLatestStationReadingsAsync(LatestStationReadingsRequest request)
        {
            return await _rainfallService.GetLatestStationReadingsAsync(request.StationId, request.Maximum);
        }
    }
}