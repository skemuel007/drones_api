using drones_api.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace drones_api.Dtos.Request
{
    public class DroneModelCreateDto
    {
        private string _modelName;
        [Required(ErrorMessage = "Drone model name is required")]
        [StringLength(90, ErrorMessage = "Drone model name can't be longer than 90 characters")]
        public string ModelName { get { return _modelName.FirstLetterToCaps().Trim();  } set { _modelName = value; } }
        [JsonIgnore]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
    }
}
