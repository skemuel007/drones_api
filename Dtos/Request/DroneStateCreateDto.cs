using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace drones_api.Dtos.Request
{
    public class DroneStateCreateDto
    {
        private string _stateTitle;
        [Required(ErrorMessage = "Drone state title is required.")]
        [StringLength(90, ErrorMessage = "Drone state title can't be longer than 90 characters.")]
        public string StateTitle { get { return _stateTitle.ToUpper().Trim(); } set { _stateTitle = value; } }
        [JsonIgnore]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
    }
}
