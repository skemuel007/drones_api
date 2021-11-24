using drones_api.Data;
using drones_api.Dtos.Request;
using drones_api.Models;
using drones_api.Paging;
using drones_api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneStateRepository : RepositoryBase<DroneState>, IDroneStateRepository
    {
        public DroneStateRepository(DronesApiContext context) : base(context) { }

        public async Task<PagedList<DroneState>> GetDroneStatesPagedAsync(DroneStateParameters droneStateParameters, bool trackChanges)
        {
            var query = FindAll(trackChanges)
                .AsQueryable();

            if (!string.IsNullOrEmpty(droneStateParameters.Filter))
            {
                query = droneStateParameters.Filter.ToLower() switch
                {
                    "active" => query.Where(d => d.Status.ToLower() == "active"),
                    "disable" => query.Where(d => d.Status.ToLower() == "disable"),
                    _ => query
                };
            }

            if (!string.IsNullOrEmpty(droneStateParameters.OrderBy))
            {
                query = droneStateParameters.OrderBy.ToLower() switch
                {
                    "dronestateid" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.DroneStateId) : query.OrderBy(d => d.DroneStateId),
                    "createdat" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.CreatedAt) : query.OrderBy(d => d.CreatedAt),
                    "updatedat" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.UpdatedAt) : query.OrderBy(d => d.UpdatedAt),
                    "name" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.StateTitle) : query.OrderBy(d => d.StateTitle),
                    "statetitle" => droneStateParameters.DescendingOrder ? query.OrderByDescending(d => d.StateTitle) : query.OrderBy(d => d.StateTitle),
                    _ => query
                };
            }

            if (!string.IsNullOrEmpty(droneStateParameters.SearchTerm))
            {
                var lowerCaseTerm = droneStateParameters.SearchTerm.Trim().ToLower();

                query = query.Where(d => d.StateTitle.ToLower().Contains(lowerCaseTerm));
            }

            var droneStates = await query.ToListAsync();

            return PagedList<DroneState>
                .ToPagedList(droneStates, droneStateParameters.PageNumber, droneStateParameters.PageSize);
        }
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
        public async Task<DroneState> GetDroneStateAsync(Guid droneStateId, bool trackChanges)
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
