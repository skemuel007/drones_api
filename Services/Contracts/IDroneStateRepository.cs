using drones_api.Models;
using System;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IDroneStateRepository
    {
        Task<bool> CheckDroneStateExists(Guid droneStateId);
        Task<DroneState> GetDroneModelAsync(Guid droneStateId, bool trackChanges);
        DroneState AddDroneState(DroneState droneState);
        bool UpdateDroneState(DroneState droneState);
        bool DeleteDroneState(DroneState droneState);
    }
}
