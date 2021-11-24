using drones_api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneRepository : RepositoryBase<Drone>, IDroneRepository
    {
        public DroneRepository(DronesApiContext context) : base(context) { }
    }
}
