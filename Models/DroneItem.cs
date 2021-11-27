using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace drones_api.Models
{
    public class DroneItem
    {
        [Key]
        public Guid DroneItemId { get; set; }
        public Guid DroneRequestId { get; set; }
        public virtual DroneRequest DroneRequest { get; set; }
        public Guid MedicationId { get; set; }
        public virtual Medication Medication {get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
