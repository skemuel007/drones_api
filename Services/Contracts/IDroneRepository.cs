using drones_api.Dtos.Request;
using drones_api.Models;
using drones_api.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IDroneRepository
    {
        Task<bool> CheckDroneExists(Guid droneId);
        Task<PagedList<Drone>> GetDroneStatesPagedAsync(DroneParameters droneParameters, bool trackChanges);
        Task<Drone> GetDroneAsync(Guid droneId, bool trackChanges);
        Drone AddDrone(Drone drone);
        bool UpdateDrone(Drone drone);
        void GetAllDroneBatteryLevels();
    }
}
