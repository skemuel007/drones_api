using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Models
{
    public class Medication
    {
        [Key]
        public Guid MedicationId { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Weight { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<DroneMedication> DroneMedications { get; set; }
    }
}
