using drones_api.Dtos.Response;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Controllers.V1
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HealthsController : ControllerBase
    {
        private readonly ILogger<HealthsController> _logger;
        private readonly HealthCheckService _healthCheckService;

        /// <summary>
        /// Constructor - with Logger and Health Check Service 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="healthCheckService"></param>
        public HealthsController(ILogger<HealthsController> logger,
            HealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the health response of the api
        /// </summary>
        /// <returns>Returns the health status of the service</returns>
        /// <returns code="200">Successful - Service is running fine</returns>
        /// <returns code="503">Unsuccessful - Issue with the service</returns>
        [HttpGet("application")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<HealthReportResponseDto>))]
        [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> Get()
        {
            HealthReport report = await _healthCheckService.CheckHealthAsync();

            if (report.Status == HealthStatus.Healthy)
            {
                return Ok(new
                {
                    Status = true,
                    Message = "Successful",
                    Data = report
                });
            }

            return StatusCode(StatusCodes.Status503ServiceUnavailable, new
            {
                Status = false,
                Message = "Service is unavailable",
                Data = report
            });
        }
    }
}
