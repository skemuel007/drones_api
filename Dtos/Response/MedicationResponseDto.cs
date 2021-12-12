using drones_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Dtos.Response
{
    public class MedicationResponseDto
    {
        public Guid MedicationId { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<DroneItem> DroneItems { get; set; }
    }
}
