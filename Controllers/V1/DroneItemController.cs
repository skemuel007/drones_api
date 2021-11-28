using AutoMapper;
using drones_api.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
    public class DroneItemController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public DroneItemController(IRepositoryManager repositoryManager,
            IMapper mapper, IMemoryCache memoryCache)
        {
            _repository = repositoryManager;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Gets loaded item for a drone that is currently active
        /// </summary>
        /// <param name="droneId"></param>
        /// <returns></returns>
        [HttpGet("drone/{droneId}")]
        public async Task<IActionResult> GetLoadedItemsForDrone(Guid droneId)
        {
            // confirm drone exists
            var droneExists = await _repository.Drone.CheckDroneExists(droneId);

            if ( !droneExists )
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Drone with id {droneId} does not exists",
                    Data = new { }
                });
            }
            // get drone where status is loaded from DroneRequest

            var droneRequest = await _repository.DroneRequest.GetDroneRequestByStatus(droneId: droneId, status: "loaded", trackChanges: false);

            // use request id to get loaded items
            if (droneRequest.DroneItems.Count == 0)
                return NotFound(new
                {
                    Status = false,
                    Message = $"No items loaded for this drone",
                    Data = new object[0]
                });

            return Ok(new
            {
                Status = true,
                Message = $"Drone items loaded for this drone",
                Data = droneRequest.DroneItems
            });

        }
    }
}
