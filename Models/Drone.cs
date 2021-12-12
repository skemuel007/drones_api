using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Models
{
    public class Drone
    {
        [Key]
        public Guid DroneId { get; set; }
        [MaxLength(100, ErrorMessage = "Serial number cannot be more than 100 characters in length")]
        public string SerialNumber { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal WeightLimit { get; set; }
        public int BatterCapacity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid DroneModelId { get; set; }
        public virtual DroneModel DroneModel { get; set; }
        public Guid DroneStateId { get; set; }
        public virtual DroneState DroneState { get; set; }
        public virtual ICollection<DroneRequest> DroneRequests {get; set;}
    }
}
