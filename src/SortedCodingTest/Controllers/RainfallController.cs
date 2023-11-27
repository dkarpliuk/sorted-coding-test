﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("id/{stationId}/readings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(ErrorResponse))]
        public async Task<RainfallReadingResponse> GetLatestStationReadingsAsync([FromRoute, FromQuery] LatestStationReadingsRequest request)
        {
            return await _rainfallService.GetLatestStationReadingsAsync(request.StationId, request.Maximum);
        }
    }
}