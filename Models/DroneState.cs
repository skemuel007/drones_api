using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Models
{
    public class DroneState
    {
        [Key]
        public Guid DroneStateId { get; set; }
        [Required]
        [MaxLength(150)]
        public string StateTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
