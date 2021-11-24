using AutoMapper;
using drones_api.Dtos.Request;
using drones_api.Dtos.Response;
using drones_api.Models;
using drones_api.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class DroneStateController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DroneStateController(IRepositoryManager repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets a page list of drone states
        /// </summary>
        /// <param name="droneStateParameters"></param>
        /// <returns>Returns a paged list of drone states</returns>
        /// <returns code="200">Successful</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ICollection<DroneState>>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> GetDroneStates([FromQuery] DroneStateParameters droneStateParameters)
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
            var droneStates = await _repository.DroneState.GetDroneStatesPagedAsync(droneStateParameters, trackChanges: false);

            return Ok(new
            {
                Status = (droneStates.Count > 0) ? true : false,
                Meta = droneStates.PagedResponse,
                Message = (droneStates.Count > 0) ? "Drone states found" : "No drone states found",
                Data = droneStates
            });
        }

        /// <summary>
        /// Gets the drone state
        /// </summary>
        /// <param name="droneStateId"></param>
        /// <returns>A drone state record by its Guid</returns>
        /// <returns code="200">Ok - Drone state record found</returns>
        /// <returns code="404">Not found - No such drone state</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet("{droneStateId}", Name = "GetDroneState")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<Object>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<DroneState>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<Object>))]
        public async Task<IActionResult> GetDroneState(Guid droneStateId)
        {
            // check if drone model exists
            var exists = await _repository.DroneState.CheckDroneStateExists(droneStateId);

            if (!exists)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "No such drone state",
                    Data = new { }
                });
            }

            // get the drone model
            var droneState = await _repository.DroneState.GetDroneStateAsync(droneStateId: droneStateId, trackChanges: false);

            return Ok(new
            {
                Status = true,
                Message = "Drone state record found",
                Data = droneState
            });

        }

        /// <summary>
        /// Creates a new drone state
        /// </summary>
        /// <param name="droneStateCreateDto"></param>
        /// <returns>Created drone state</returns>
        /// <returns code="201">Created successfully</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="400">Bad request - No payload sent</returns>
        /// <returns code="500">Internal server error - Error while adding to database</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<DroneState>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public IActionResult AddDroneState([FromBody] DroneStateCreateDto droneStateCreateDto)
        {
            if (droneStateCreateDto == null)
            {
                // todo serilog error
                return BadRequest(new
                {
                    Status = false,
                    Message = "Drone model object is null",
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

            var droneStateEntity = _mapper.Map<DroneState>(droneStateCreateDto);

            var createdModelState = _repository.DroneState.AddDroneState(droneStateEntity);

            return StatusCode(StatusCodes.Status201Created, new
            {
                Status = true,
                Message = "New drone state created",
                Data = createdModelState
            });
        }

        /// <summary>
        /// Update a drone state
        /// </summary>
        /// <param name="droneStateId"></param>
        /// <param name="droneStateUpdateDto"></param>
        /// <returns>Updated drone message</returns>
        /// <returns code="200">Update successfully</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="400">Bad request - No payload sent</returns>
        /// <returns code="500">Internal server error - Error while adding to database</returns>
        [HttpPut("{droneStateId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> UpdateDroneState(Guid droneStateId, [FromBody] DroneStateUpdateDto droneStateUpdateDto)
        {
            if (droneStateUpdateDto == null)
            {
                // todo serilog error
                return BadRequest(new
                {
                    Status = false,
                    Message = "Drone state object is null",
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

            var droneStateEntity = await _repository.DroneState.GetDroneStateAsync(droneStateId: droneStateId, trackChanges: false);

            if (droneStateEntity == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Drone state with id: {droneStateId}, was not found",
                    Data = new { }
                });
            }

            _mapper.Map(droneStateUpdateDto, droneStateEntity);

            if (_repository.DroneState.UpdateDroneState(droneStateEntity))
            {
                return Ok(new
                {
                    Status = true,
                    Message = $"Drone mode {droneStateId} updated successfully",
                    Data = new { }
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Status = false,
                Message = $"An error occured while updating drone model {droneStateId}, please try again later",
                Data = new { }
            });
        }

        /// <summary>
        /// Deletes a drone state
        /// </summary>
        /// <param name="droneStateId"></param>
        /// <returns>Success - drone state deleted</returns>
        /// <returns code="200">Drone state successfully deleted</returns>
        /// <returns code="404">Drone state not found</returns>
        /// <returns code="500">Internal server error - something went wrong deleting drone state record</returns>
        [HttpDelete("{droneStateId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> DeleteDroneModel(Guid droneStateId)
        {
            var droneState = await _repository.DroneState.GetDroneStateAsync(droneStateId, false);

            if (droneState == null)
            {
                // log error
                return NotFound(new
                {
                    Status = false,
                    Message = $"Drone state with id: {droneStateId}, was not found",
                    Data = new { }
                });
            }

            var isDeleted = _repository.DroneState.DeleteDroneState(droneState);

            if (isDeleted)
                return Ok(new
                {
                    Status = true,
                    Message = $"Drone state ${droneStateId} deleted",
                    Data = new { }
                });

            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: new
            {
                Status = false,
                Message = $"Something went wrong while deleting drone state {droneStateId}.",
                Data = new { }
            });
        }
    }
}
