using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace drones_api.Models
{
    public class DroneRequest
    {
        [Key]
        public Guid DroneRequestId { get; set; }
        public Guid DroneId { get; set; }
        public virtual Drone Drone { get; set; }

        public string From { get; set; }
        public string To { get; set; }
        public string Status { get; set; }  // loaded/ delivered

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<DroneItem> DroneItems { get; set; }

    }
}
