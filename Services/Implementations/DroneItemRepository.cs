using drones_api.Data;
using drones_api.Models;
using drones_api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneItemRepository : RepositoryBase<DroneItem>, IDroneItemRepository{ 
        public DroneItemRepository(DronesApiContext context) : base(context) { }

        public DroneItem AddDroneItem(DroneItem droneItem)
        {
            var createdDroneItem = Add(droneItem);
            return createdDroneItem;
        }
    }
}
