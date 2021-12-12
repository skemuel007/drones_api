using drones_api.Data;
using drones_api.Models;
using drones_api.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneRequestRepository : RepositoryBase<DroneRequest>, IDroneRequestRepository
    {
        public DroneRequestRepository(DronesApiContext context) : base(context) { }

        public IDbContextTransaction BeginTransaction()
        {
            using var transaction = DbContext.Database.BeginTransaction();
            return transaction;
        }

        public DroneRequest CreateDroneRequest(DroneRequest droneRequest)
        {
            var createdDroneRequest = Add(droneRequest);
            return createdDroneRequest;
        }

        public void Commit(IDbContextTransaction transaction)
        {
            transaction.Commit();
        }

        public async Task<DroneRequest> GetDroneRequestByStatus(Guid droneId, string status, bool trackChanges)
        {
            var droneRequest = await FindByCondition(d => d.Status.ToLower() == status && d.DroneId == droneId, trackChanges)
                .Include(d => d.DroneItems)
                .FirstOrDefaultAsync();
            return droneRequest;
        }
    }
}
