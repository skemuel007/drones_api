using System;
using System.Text.Json.Serialization;

namespace drones_api.Dtos.Request
{
    public class DroneItemDto
    {
        public Guid MedicationId { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        [JsonIgnore]
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
    }
}
