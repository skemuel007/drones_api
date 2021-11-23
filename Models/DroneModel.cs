using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Models
{
    public class DroneModel
    {
        [Key]
        public Guid DroneModelId { get; set; }
        [Required]
        [MaxLength(150)]
        public string ModelName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
