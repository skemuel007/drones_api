using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Dtos.Request
{
    public class LoadDroneDto
    {
        [Required]
        public Guid DroneId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        [Required]
        public ICollection<DroneItemDto> Items { get; set; }
    }
}
