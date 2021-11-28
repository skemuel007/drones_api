using drones_api.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IDroneRequestRepository
    {
        IDbContextTransaction BeginTransaction();
        DroneRequest CreateDroneRequest(DroneRequest droneRequest);
        void Commit(IDbContextTransaction transaction);
        Task<DroneRequest> GetDroneRequestByStatus(Guid droneId, string status, bool trackChanges);
    }
}
