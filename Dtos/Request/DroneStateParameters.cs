using drones_api.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Dtos.Request
{
    public class DroneStateParameters : RequestParams
    {
        public DroneStateParameters()
        {
            OrderBy = "name";
        }
        public string Filter { get; set; }
        public string SearchTerm { get; set; }
        public bool DescendingOrder { get; set; }
    }
}
