using AutoMapper;
using drones_api.Dtos.Request;
using drones_api.Dtos.Response;
using drones_api.Middlewares;
using drones_api.Models;
using drones_api.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace drones_api.Controllers.V1
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public MedicationController(IRepositoryManager repositoryManager,
            IMapper mapper,
            IMemoryCache memoryCache)
        {
            _repository = repositoryManager;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Gets a page list of medications
        /// </summary>
        /// <param name="medicationParameters"></param>
        /// <returns>Returns a paged list of medication</returns>
        /// <returns code="200">Successful</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ICollection<Medication>>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "*" })]
        public async Task<IActionResult> GetMedications([FromQuery] MedicationParameters medicationParameters)
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
            var medications = await _repository.Medication.GetMedicationPagedAsync(medicationParameters, trackChanges: false);

            return Ok(new
            {
                Status = (medications.Count > 0) ? true : false,
                Meta = medications.PagedResponse,
                Message = (medications.Count > 0) ? "Medications found" : "No medication data found",
                Data = medications
            });
        }

        /// <summary>
        /// Gets the medication
        /// </summary>
        /// <param name="medicationId"></param>
        /// <returns>A medication by its Guid</returns>
        /// <returns code="200">Ok - medication record found</returns>
        /// <returns code="404">Not found - No such medication data</returns>
        /// <returns code="500">Internal server error</returns>
        [HttpGet("{medicationId}", Name = "GetMedication")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<Object>))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Medication>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<Object>))]
        [RateLimitDecorator(StrategyType = StrategyTypeEnum.IpAddress)]
        public async Task<IActionResult> GetMedication(Guid medicationId)
        {
            // check if drone model exists
            var exists = await _repository.Medication.CheckMedicationExists(medicationId);

            if (!exists)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = "No such medication",
                    Data = new { }
                });
            }

            // get the drone
            var medication = await _repository.Medication.GetMedicationAsync(medicationId: medicationId, trackChanges: false);

            return Ok(new
            {
                Status = true,
                Message = "Medication record found",
                Data = medication
            });

        }

        // https://stackoverflow.com/questions/67517108/image-uploading-in-dot-net-core-web-api

        /// <summary>
        /// Add a new medicaton
        /// </summary>
        /// <param name="medicationCreateDto"></param>
        /// <returns>New medication details</returns>
        /// <returns code="201">Created successfully</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="400">Bad request - No payload sent</returns>
        /// <returns code="500">Internal server error - Error while adding to database</returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ApiResponse<Medication>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public IActionResult AddMedicationAsync([FromForm] MedicationCreateDto medicationCreateDto)
        {
            if (medicationCreateDto == null)
            {
                // todo serilog error
                return BadRequest(new
                {
                    Status = false,
                    Message = "Medication request object is null",
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

            if (medicationCreateDto.Image == null || medicationCreateDto.Image.Length == 0)
                return BadRequest(new
                {
                    Status = false,
                    Message = "No uploaded selected",
                    Data = new { }
                });

            string fileExtension = Path.GetExtension(medicationCreateDto.Image.FileName);
            if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
                return BadRequest(new
                {
                    Status = false,
                    Message = "Supported extension, .png, .jpeg and .jpg",
                    Data = new { }
                });

            var fileSize = medicationCreateDto.Image.Length;

            if ( fileSize > 10485760)
            {
                return BadRequest(new
                {
                    Status = false,
                    Message = "File cannot be greater than 10mb",
                    Data = new { }
                });
            }

            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            // create directory if not exists
            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);

            var fileName = ContentDispositionHeaderValue.Parse(medicationCreateDto.Image.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            // var dbPath = Path.Combine(folderName, fileName);


            var medicationEntity = new Medication()
            {
                Code = medicationCreateDto.Code,
                Name = medicationCreateDto.Name,
                Weight = medicationCreateDto.Weight,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            /*using (var memoryStream = new MemoryStream())
            {
                await medicationCreateDto.Image.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    medicationEntity.Image = memoryStream.ToArray();
                }
            }*/
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                medicationCreateDto.Image.CopyTo(stream);
            }

            medicationEntity.Image = System.IO.File.ReadAllBytes(fullPath);

            var createdMedication = _repository.Medication.AddMedication(medicationEntity);

            return StatusCode(StatusCodes.Status201Created, new
            {
                Status = true,
                Message = "New medication added",
                Data = createdMedication
            });
        }

        /// <summary>
        /// Updates medication details
        /// </summary>
        /// <param name="medicationId"></param>
        /// <param name="medicationUpdateDto"></param>
        /// <returns></returns>
        /// <returns code="200">Update successful</returns>
        /// <returns code="404">Record not found</returns>
        /// <returns code="422">Validation error</returns>
        /// <returns code="500">Internal server</returns>
        [HttpPut("{medicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> UpdateMedication(Guid medicationId, [FromForm] MedicationUpdateDto medicationUpdateDto)
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

            // get medication by guid 
            var medication = await _repository.Medication.GetMedication(medicationId, false);

            if (medication == null)
            {
                return NotFound(new
                {
                    Status = false,
                    Message = $"Medication with id {medicationId} not found",
                    Data = new { }
                });
            }

            if (medicationUpdateDto.Image == null || medicationUpdateDto.Image.Length == 0)
                return BadRequest(new
                {
                    Status = false,
                    Message = "No uploaded selected",
                    Data = new { }
                });

            else
            {
                string fileExtension = Path.GetExtension(medicationUpdateDto.Image.FileName);
                if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
                    return BadRequest(new
                    {
                        Status = false,
                        Message = "Supported extension, .png, .jpeg and .jpg",
                        Data = new { }
                    });

                var fileSize = medicationUpdateDto.Image.Length;

                if (fileSize > 10485760)
                {
                    return BadRequest(new
                    {
                        Status = false,
                        Message = "File cannot be greater than 10mb",
                        Data = new { }
                    });
                }
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                // create directory if not exists
                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);

                var fileName = ContentDispositionHeaderValue.Parse(medicationUpdateDto.Image.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    medicationUpdateDto.Image.CopyTo(stream);
                }

                medication.Image = System.IO.File.ReadAllBytes(fullPath);
            }


            medication.Code = string.IsNullOrEmpty(medicationUpdateDto.Code) ? medication.Code : medicationUpdateDto.Code;
            medication.Name = string.IsNullOrEmpty(medicationUpdateDto.Name) ? medication.Name : medicationUpdateDto.Name;
            medication.Weight = medicationUpdateDto.Weight;
            medication.UpdatedAt = DateTime.Now;

            

            
            if (_repository.Medication.UpdateMedication(medication))
            {
                return Ok(new
                {
                    Status = true,
                    Message = $"Medication {medicationId} updated successfully",
                    Data = new { }
                });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                Status = false,
                Message = $"An error occured while updating medication with Id, {medicationId}, please try again later",
                Data = new { }
            });
        }

        /// <summary>
        /// Deletes medications
        /// </summary>
        /// <param name="medicationId"></param>
        /// <returns>Success - medication deleted</returns>
        /// <returns code="200">Medication successfully deleted</returns>
        /// <returns code="404">Medication record not found</returns>
        /// <returns code="500">Internal server error - something went wrong deleting medication record</returns>
        [HttpDelete("{medicationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<object>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<object>))]
        public async Task<IActionResult> DeleteMedication(Guid medicationId)
        {
            var medication = await _repository.Medication.GetMedication(medicationId, false);

            if (medication == null)
            {
                // log error
                return NotFound(new
                {
                    Status = false,
                    Message = $"Medication with id: {medicationId}, was not found",
                    Data = new { }
                });
            }

            var isDeleted = _repository.Medication.DeleteMedication(medication);

            if (isDeleted)
                return Ok(new
                {
                    Status = true,
                    Message = $"Medication ${medicationId} deleted",
                    Data = new { }
                });

            return StatusCode(statusCode: StatusCodes.Status500InternalServerError, value: new
            {
                Status = false,
                Message = $"Something went wrong while deleting medication {medicationId}.",
                Data = new { }
            });
        }
    }
}
