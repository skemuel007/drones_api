using drones_api.Data;
using drones_api.Models;
using drones_api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneStateRepository : RepositoryBase<DroneState>, IDroneStateRepository
    {
        public DroneStateRepository(DronesApiContext context) : base(context) { }

        /// <summary>
        /// Check if the drone state exists
        /// </summary>
        /// <param name="droneStateId"></param>
        /// <returns>Returns true if exists else false</returns>
        public async Task<bool> CheckDroneStateExists(Guid droneStateId)
        {
            var exists = await CheckExists(d => d.DroneStateId == droneStateId);
            return exists;
        }

        /// <summary>
        /// Gets a single drone state with matching id
        /// </summary>
        /// <param name="droneStateId"></param>
        /// <param name="trackChanges"></param>
        /// <returns>A drone state instance or null if not found</returns>
        public async Task<DroneState> GetDroneModelAsync(Guid droneStateId, bool trackChanges)
        {
            var droneState = await FindByCondition(d => d.DroneStateId == droneStateId, trackChanges: trackChanges)
                .FirstOrDefaultAsync();
            return droneState;
        }

        /// <summary>
        /// Add a new drone state
        /// </summary>
        /// <param name="droneState"></param>
        /// <returns>Returns a drone model instance</returns>
        public DroneState AddDroneState(DroneState droneState)
        {
            var addedDroneState = Add(droneState);
            return addedDroneState;
        }

        /// <summary>
        /// Updates an existing drone state
        /// </summary>
        /// <param name="droneState"></param>
        /// <returns>Returns true if successful and false if not</returns>
        public bool UpdateDroneState(DroneState droneState)
        {
            Update(droneState);
            return SaveChanges();
        }

        /// <summary>
        /// Deletes a drone state
        /// </summary>
        /// <param name="droneState"></param>
        /// <returns>Returns true if successful and false if not</returns>
        public bool DeleteDroneState(DroneState droneState)
        {
            Delete(droneState);
            return SaveChanges();
        }


    }
}
