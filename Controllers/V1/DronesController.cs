using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using drones_api.Models;
using Microsoft.AspNetCore.Cors;
using drones_api.Services.Contracts;
using AutoMapper;
using drones_api.Dtos.Response;
using drones_api.Dtos.Request;
using drones_api.Middlewares;

namespace drones_api.Data
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DronesController(IRepositoryManager repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets a page list of drone models
        /// </summary>
        /// <param name="droneParameters"></param>
        /// <returns>Returns a paged list of drone</returns>
        /// <returns code="200">Successful</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ICollection<Drone>>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new[] { "OrderBy", "SearchTerm", "Filter", "DescendingOrder" })]
        public async Task<IActionResult> GetDrones([FromQuery] DroneParameters droneParameters)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(new
                {
                    Status = false,
                    Message = ModelState,
                    Data = new { }
                });
            }
            var drones = await _repository.Drone.GetDroneStatesPagedAsync(droneParameters, trackChanges: false);

            return Ok(new
            {
                Status = (drones.Count > 0) ? true : false,
                Meta = drones.PagedResponse,
                Message = (drones.Count > 0) ? "Drone found" : "No drone found",
                Data = drones
            });
        }

        /// <summary>
        /// Gets the drone
        /// </summary>
        /// <param name="droneId"></param>
        /// <returns>A drone record by its Guid</returns>
        /// <returns code="200">Ok - Drone record found</returns>
        /// <returns code="404">Not found - No such drone</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet("{droneId}", Name = "GetDrone")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<Object>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Drone>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<Object>))]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        public async Task<IActionResult> GetDrone(Guid droneId)
        {
            // check if drone model exists
            var exists = await _repository.Drone.CheckDroneExists(droneId);

            if (!exists)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "No such drone",
                    Data = new { }
                });
            }

            // get the drone
            var drone = await _repository.Drone.GetDroneAsync(droneId: droneId, trackChanges: false);

            return Ok(new
            {
                Status = true,
                Message = "Drone record found",
                Data = drone
            });

        }

        /// <summary>
        /// Register a new drone detail
        /// </summary>
        /// <param name="droneCreateDto"></param>
        /// <returns>Created drone model</returns>
        /// <returns code="201">Created successfully</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="400">Bad request - No payload sent</returns>
        /// <returns code="500">Internal server error - Error while adding to database</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Drone>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> AddDroneModel([FromBody] DroneCreateDto droneCreateDto)
        {
            if (droneCreateDto == null)
            {
                // todo serilog error
                return BadRequest(new
                {
                    Status = false,
                    Message = "Drone object is null",
                    Data = new { }
                });
            }

            if (!ModelState.IsValid)
            {
                // Todo - serilog error
                return UnprocessableEntity(new
                {
                    Status = false,
                    Message = ModelState,
                    Data = new { }
                });
            }

            var droneStateExists = await _repository.DroneState.CheckDroneStateExists(droneCreateDto.DroneStateId);
            var dorneModelEixsts = await _repository.DroneModel.CheckDroneModelExists(droneCreateDto.DroneModelId);

            if ( !droneStateExists )
            {
                NotFound(new
                {
                    Status = false,
                    Message = $"State for drone is invalid",
                    Data = new { }
                });
            }

            if (!dorneModelEixsts)
            {
                NotFound(new
                {
                    Status = false,
                    Message = $"Model for drone is invalid",
                    Data = new { }
                });
            }

            var droneEntity = _mapper.Map<Drone>(droneCreateDto);

            var createdDrone = _repository.Drone.AddDrone(droneEntity);

            return StatusCode(StatusCodes.Status201Created, new
            {
                Status = true,
                Message = "New drone created",
                Data = createdDrone
            });
        }
    }
}
