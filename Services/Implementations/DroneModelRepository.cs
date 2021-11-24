using drones_api.Data;
using drones_api.Models;
using drones_api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneModelRepository : RepositoryBase<DroneModel>, IDroneModelRepository
    {
        public DroneModelRepository(DronesApiContext context) : base(context) { }

        /// <summary>
        /// Check if the drone model exists
        /// </summary>
        /// <param name="droneModelId"></param>
        /// <returns></returns>
        public async Task<bool> CheckDroneModelExists(Guid droneModelId)
        {
            var exists = await CheckExists(d => d.DroneModelId == droneModelId);
            return exists;
        }

        /// <summary>
        /// Gets a single drone model with matching id
        /// </summary>
        /// <param name="droneModelId"></param>
        /// <param name="trackChanges"></param>
        /// <returns>A drone model instance or null</returns>
        public async Task<DroneModel> GetDroneModelAsync(Guid droneModelId, bool trackChanges)
        {
            var droneModel = await FindByCondition(d => d.DroneModelId == droneModelId, trackChanges: trackChanges)
                .FirstOrDefaultAsync();
            return droneModel;
        }
        
        /// <summary>
        /// Add a new drone model
        /// </summary>
        /// <param name="droneModel"></param>
        /// <returns>Returns a drone model instance</returns>
        public DroneModel AddDroneModel(DroneModel droneModel)
        {
            var addedDroneModel = Add(droneModel);
            return addedDroneModel;
        }

        /// <summary>
        /// Updates an existing drone model
        /// </summary>
        /// <param name="droneModel"></param>
        /// <returns>Returns true if successful and false if not</returns>
        public bool UpdateDroneModel(DroneModel droneModel)
        {
            Update(droneModel);
            return SaveChanges();
        }

        /// <summary>
        /// Deletes a drone model
        /// </summary>
        /// <param name="droneModel"></param>
        /// <returns>Returns true if successful and false if not</returns>
        public bool DeleteDroneModel(DroneModel droneModel)
        {
            Delete(droneModel);
            return SaveChanges();
        }

    }
}
