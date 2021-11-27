using drones_api.Data;
using drones_api.Dtos.Request;
using drones_api.Models;
using drones_api.Paging;
using drones_api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneRepository : RepositoryBase<Drone>, IDroneRepository
    {
        public DroneRepository(DronesApiContext context) : base(context) { }

        public async Task<PagedList<Drone>> GetDroneStatesPagedAsync(DroneParameters droneParameters, bool trackChanges)
        {
            var query = FindAll(trackChanges)
                .Include(d => d.DroneState)
                .Include(d => d.DroneModel)
                .AsQueryable();

            if (!string.IsNullOrEmpty(droneParameters.Filter))
            {
                query = droneParameters.Filter.ToLower() switch
                {
                    "idle" => query.Where(d => d.DroneState.StateTitle.ToLower() == "idle"),
                    "loading" => query.Where(d => d.DroneState.StateTitle.ToLower() == "loading"),
                    "loaded" => query.Where(d => d.DroneState.StateTitle.ToLower() == "loaded"),
                    "delivering" => query.Where(d => d.DroneState.StateTitle.ToLower() == "delivering"),
                    "delivered" => query.Where(d => d.DroneState.StateTitle.ToLower() == "delivered"),
                    "returning" => query.Where(d => d.DroneState.StateTitle.ToLower() == "returning"),
                    "lightweight" => query.Where(d => d.DroneModel.ModelName.ToLower() == "lightweight"),
                    "middleweight" => query.Where(d => d.DroneModel.ModelName.ToLower() == "middleweight"),
                    "cruiserweight" => query.Where(d => d.DroneModel.ModelName.ToLower() == "cruiserweight"),
                    "heavyweight" => query.Where(d => d.DroneModel.ModelName.ToLower() == "heavyweight"),
                    _ => query
                };
            }

            if (!string.IsNullOrEmpty(droneParameters.OrderBy))
            {
                query = droneParameters.OrderBy.ToLower() switch
                {
                    "serialnumber" => droneParameters.DescendingOrder ? query.OrderByDescending(d => d.SerialNumber) : query.OrderBy(d => d.SerialNumber),
                    "createdat" => droneParameters.DescendingOrder ? query.OrderByDescending(d => d.CreatedAt) : query.OrderBy(d => d.CreatedAt),
                    "updatedat" => droneParameters.DescendingOrder ? query.OrderByDescending(d => d.UpdatedAt) : query.OrderBy(d => d.UpdatedAt),
                    _ => query
                };
            }

            if (!string.IsNullOrEmpty(droneParameters.SearchTerm))
            {
                var lowerCaseTerm = droneParameters.SearchTerm.Trim().ToLower();

                query = query.Where(d => d.DroneModel.ModelName.ToLower().Contains(lowerCaseTerm) || d.DroneState.StateTitle.ToLower().Contains(lowerCaseTerm) ||
                    d.SerialNumber.ToLower().Contains(lowerCaseTerm));
            }

            var drones = await query.ToListAsync();

            return PagedList<Drone>
                .ToPagedList(drones, droneParameters.PageNumber, droneParameters.PageSize);
        }
        public async Task<bool> CheckDroneExists(Guid droneId)
        {
            var exists = await CheckExists(d => d.DroneId == droneId);
            return exists;
        }
        public async Task<Drone> GetDroneAsync(Guid droneId, bool trackChanges)
        {
            var drone = await FindByCondition(d => d.DroneId == droneId, trackChanges)
                .FirstOrDefaultAsync();
            return drone;
        }

        public Drone AddDrone(Drone drone)
        {
            var addedDrone = Add(drone);
            return addedDrone;
        }

        public bool UpdateDrone(Drone drone)
        {
            Update(drone);
            return SaveChanges();
        }

        public void GetAllDroneBatteryLevels()
        {
            throw new NotImplementedException();
        }
    }
}
