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
using drones_api.Helpers;
using Microsoft.Extensions.Caching.Memory;

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
        private readonly IMemoryCache _memoryCache;

        public DronesController(IRepositoryManager repository,
            IMemoryCache memoryCache,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _memoryCache = memoryCache;
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
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "*" })]
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

            var dorneModelEixsts = await _repository.DroneModel.CheckDroneModelExists(droneCreateDto.DroneModelId);

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

            var cacheKey = "droneStateGuidData";
            if (!_memoryCache.TryGetValue(cacheKey, out DroneStateGuidDto droneStateGuidDto))
            {
                // get the drone model
                droneStateGuidDto = await _repository.DroneState.GetIDleDroneState(trackChanges: false);
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                };
                _memoryCache.Set(cacheKey, droneStateGuidDto, cacheExpiryOptions);
            }

            var createdDrone = _repository.Drone.AddDrone(droneEntity);

            return StatusCode(StatusCodes.Status201Created, new
            {
                Status = true,
                Message = "New drone created",
                Data = createdDrone
            });
        }

        /// <summary>
        /// Loads a drone with items
        /// </summary>
        /// <param name="loadDroneDto"></param>
        /// <returns></returns>
        [HttpPost("load")]
        public async Task<IActionResult> LoadDroneWithMedicationItems([FromBody] LoadDroneDto loadDroneDto)
        {
            // validate model state
            if ( !ModelState.IsValid)
            {
                return UnprocessableEntity(new
                {
                    Status = false,
                    Message = ModelState,
                    Data = new { }
                });
            }

            // get drone by guid 
            var drone = await _repository.Drone.GetDroneAsync(loadDroneDto.DroneId, false);

            if ( drone == null )
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Drone with id {loadDroneDto.DroneId} not found",
                    Data = new {}
                });
            }

            // get drone weight limit
            var droneWeightLimit = drone.WeightLimit;
            // check the status of the drone
            if ( drone.DroneState.StateTitle.ToLower() != "idle")
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = $"Drone cannot be loaded because drone is {drone.DroneState.StateTitle.FirstLetterToCaps()}",
                    Data = new { }
                });
            }
            // check the battery level
            if (drone.BatterCapacity < 25)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = $"Drone cannot be loaded because drone is {drone.DroneState.StateTitle.FirstLetterToCaps()}",
                    Data = new { }
                });
            }

            var droneItems = loadDroneDto.Items;

            decimal totalItemWeight = 0m;

            // calculate drone weight to see if weight is greater than
            foreach (var droneItem in droneItems)
            {
                totalItemWeight += droneItem.Weight * droneItem.Quantity;
            }

            if (totalItemWeight > droneWeightLimit)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = $"Total items weight of {totalItemWeight} exceeds drone weight limit of {droneWeightLimit}",
                    Data = new { }
                });
            }


            // create drone request
            // begin transaction
            var droneRequestTransaction = _repository.DroneRequest.BeginTransaction();

            var droneRequest = _repository.DroneRequest.CreateDroneRequest(new DroneRequest
            {
                DroneId = drone.DroneId,
                From = loadDroneDto.From,
                To = loadDroneDto.To,
                Status = "Loaded",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });

            
            if ( droneRequest != null )
            {
                foreach (var item in droneItems)
                {
                    // add each item
                    _repository.DroneItem.AddDroneItem(new DroneItem
                    {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        DroneRequestId = droneRequest.DroneRequestId,
                        MedicationId = item.MedicationId,
                        Quantity = item.Quantity,
                        Weight = item.Weight
                    });
                }

                _repository.DroneRequest.Commit(droneRequestTransaction);
            }

            // do update drone status - loading

            var droneState = await _repository.DroneState.GetDroneStateByStateTitle("Loaded", false);
            drone.DroneStateId = droneState.DroneStateId;
            drone.UpdatedAt = DateTime.Now;

            _repository.Drone.UpdateDrone(drone);
            
            return StatusCode(StatusCodes.Status201Created, new{
                Status = true,
                Message = $"Drone loaded"

            });
        }

        /// <summary>
        /// Updates drones details
        /// </summary>
        /// <param name="droneId"></param>
        /// <param name="updateDroneDto"></param>
        /// <returns></returns>
        /// <returns code="200">Update successful</returns>
        /// <returns code="404">Record not found</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="500">Internal server</returns>
        [HttpPut("{droneId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> UpdateDrone(Guid droneId, [FromBody] UpdateDroneDto updateDroneDto)
        {
            // validate model state
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(new
                {
                    Status = false,
                    Message = ModelState,
                    Data = new { }
                });
            }

            // get drone by guid 
            var drone = await _repository.Drone.GetDroneAsync(droneId, false);

            if (drone == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Drone with id {droneId} not found",
                    Data = new { }
                });
            }

            _mapper.Map(updateDroneDto, drone);

            if (_repository.Drone.UpdateDrone(drone))
            {
                return Ok(new
                {
                    Status = true,
                    Message = $"Drone {droneId} updated successfully",
                    Data = new { }
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Status = false,
                Message = $"An error occured while updating drone with Id, {droneId}, please try again later",
                Data = new { }
            });
        }
    }
}
