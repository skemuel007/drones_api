using drones_api.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace drones_api.Dtos.Request
{
    public class DroneCreateDto
    {
        [Required( ErrorMessage = "Drone serial number is required.")]
        [StringLength(100, ErrorMessage = "Serial number can't be longer than 100 characters.")]
        public string SerialNumber { get; set; }
        [Required( ErrorMessage = "Weight limit is required")]
        [ValidateDroneWeightLimit]
        public decimal WeightLimit { get; set; }
        [Required]
        [ValidateBatteryPercentage]
        public int BatterCapacity { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
        [Required]
        public Guid DroneModelId { get; set; }
    }
}
