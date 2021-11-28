using System;

namespace drones_api.Dtos.Response
{
    public class BatteryLevelsDto
    {
        public int BatteryCapacity { get; set; }
        public Guid DroneId { get; set; }
    }
}
