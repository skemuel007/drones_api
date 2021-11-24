using drones_api.Dtos.Request;
using drones_api.Models;
using drones_api.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IDroneModelRepository
    {
        Task<PagedList<DroneModel>> GetDroneModelsPagedAsync(DroneModelParameters droneModelParameters, bool trackChanges);
        Task<bool> CheckDroneModelExists(Guid droneModelId);
        Task<DroneModel> GetDroneModelAsync(Guid droneModelId, bool trackChanges);
        DroneModel AddDroneModel(DroneModel droneModel);
        bool UpdateDroneModel(DroneModel droneModel);
        bool DeleteDroneModel(DroneModel droneModel);

    }
}
