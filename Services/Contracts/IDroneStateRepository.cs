using drones_api.Dtos.Request;
using drones_api.Models;
using drones_api.Paging;
using System;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IDroneStateRepository
    {
        Task<PagedList<DroneState>> GetDroneStatesPagedAsync(DroneStateParameters droneStateParameters, bool trackChanges);
        Task<bool> CheckDroneStateExists(Guid droneStateId);
        Task<DroneState> GetDroneStateAsync(Guid droneStateId, bool trackChanges);
        DroneState AddDroneState(DroneState droneState);
        bool UpdateDroneState(DroneState droneState);
        bool DeleteDroneState(DroneState droneState);
    }
}
