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
    public class DroneModelController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public DroneModelController(IRepositoryManager repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the drone model
        /// </summary>
        /// <param name="droneModelId"></param>
        /// <returns>A drone model record by its Guid</returns>
        /// <returns code="200">Ok - Drone model record found</returns>
        /// <returns code="404">Not found - No such drone model</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet("{droneModelId}", Name = "GetDroneModel")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<Object>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<DroneModel>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<Object>))]
        public async Task<IActionResult> GetDroneModel(Guid droneModelId)
        {
            // check if drone model exists
            var exists = await _repository.DroneModel.CheckDroneModelExists(droneModelId);

            if ( !exists)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "No such drone model",
                    Data = new { }
                });
            }

            // get the drone model
            var droneModel = await _repository.DroneModel.GetDroneModelAsync(droneModelId: droneModelId, trackChanges: false);

            return Ok(new
            {
                Status = true,
                Message = "Drone model record found",
                Data = droneModel
            });

        }

        /// <summary>
        /// Creates a new drone model
        /// </summary>
        /// <param name="droneModelcreateDto"></param>
        /// <returns>Created drone model</returns>
        /// <returns code="201">Created successfully</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="400">Bad request - No payload sent</returns>
        /// <returns code="500">Internal server error - Error while adding to database</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<DroneModel>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public IActionResult AddDroneModel([FromBody] DroneModelCreateDto droneModelcreateDto)
        {
            if ( droneModelcreateDto == null )
            {
                // todo serilog error
                return BadRequest(new
                {
                    Status = false,
                    Message = "Drone model object is null",
                    Data = new { }
                });
            }

            if ( !ModelState.IsValid )
            {
                // Todo - serilog error
                return UnprocessableEntity(new
                {
                    Status = false,
                    Message = ModelState,
                    Data = new { }
                });
            }

            var droneModelEntity = _mapper.Map<DroneModel>(droneModelcreateDto);

            var createdDroneModel = _repository.DroneModel.AddDroneModel(droneModelEntity);

            return StatusCode(StatusCodes.Status201Created, new
            {
                Status = true,
                Message = "New drone model created",
                Data = createdDroneModel
            });
        }

        /// <summary>
        /// Update a drone model
        /// </summary>
        /// <param name="droneModelId"></param>
        /// <param name="droneModelUpdateDto"></param>
        /// <returns>Updated drone message</returns>
        /// <returns code="200">Update successfully</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="400">Bad request - No payload sent</returns>
        /// <returns code="500">Internal server error - Error while adding to database</returns>
        [HttpPut("{droneModelId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> UpdateDroneModel(Guid droneModelId, [FromBody] DroneModelUpdateDto droneModelUpdateDto)
        {
            if (droneModelUpdateDto == null)
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

            var droneModelEntity = await _repository.DroneModel.GetDroneModelAsync(droneModelId: droneModelId, trackChanges: false);

            if ( droneModelEntity == null )
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Drone model with id: {droneModelId}, was not found",
                    Data = new { }
                });
            }

            _mapper.Map(droneModelUpdateDto, droneModelEntity);
            
            if (_repository.DroneModel.UpdateDroneModel(droneModelEntity))
            {
                return Ok(new
                {
                    Status = true,
                    Message = $"Drone mode {droneModelId} updated successfully",
                    Data = new { }
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Status = false,
                Message = $"An error occured while updating drone model {droneModelId}, please try again later",
                Data = new { }
            });
        }

        /// <summary>
        /// Deletes a drone model
        /// </summary>
        /// <param name="droneModelId"></param>
        /// <returns>Success - drone model deleted</returns>
        /// <returns code="200">Drone model successfully deleted</returns>
        /// <returns code="404">Drone model not found</returns>
        /// <returns code="500">Internal server error - something went wrong deleting drone model record</returns>
        [HttpDelete("{droneModelId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> DeleteDroneModel(Guid droneModelId)
        {
            var droneModel = await _repository.DroneModel.GetDroneModelAsync(droneModelId, false);

            if ( droneModel == null )
            {
                // log error
                return NotFound(new
                {
                    Status = false,
                    Message = $"Drone model with id: {droneModelId}, was not found",
                    Data = new { }
                });
            }

            var isDeleted = _repository.DroneModel.DeleteDroneModel(droneModel);

            if (isDeleted)
                return Ok(new
                {
                    Status = true,
                    Message = $"Drone model ${droneModelId} deleted",
                    Data = new {}
                });

            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: new
            {
                Status = false,
                Message = $"Something went wrong while deleting drone model {droneModelId}.",
                Data = new { }
            });
        }
    }
}
