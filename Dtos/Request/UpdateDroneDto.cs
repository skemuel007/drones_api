using drones_api.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace drones_api.Dtos.Request
{
    public class UpdateDroneDto
    {
        
        [ValidateDroneWeightLimit]
        public decimal WeightLimit { get; set; }
        [ValidateBatteryPercentage]
        public int BatterCapacity { get; set; }
        [JsonIgnore]
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
        [Required]
        public Guid DroneStateId { get; set; }
    }
}
