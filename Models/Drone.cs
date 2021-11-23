using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Models
{
    public class Drone
    {
        [Key]
        public Guid SerialNumber { get; set; }
        public decimal WeightLimit { get; set; }
        public int BatterCapacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
