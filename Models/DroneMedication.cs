using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Models
{
    public class DroneMedication
    {
        public Guid DroneId { get; set; }
        public virtual Drone Drone { get; set; }
        public Guid MedicationId { get; set; }
        public virtual Medication Medication { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
