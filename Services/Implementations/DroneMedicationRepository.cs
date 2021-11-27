using drones_api.Data;
using drones_api.Models;
using drones_api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class DroneMedicationRepository : RepositoryBase<DroneMedication>, IDroneMedicationRepository
    {
        public DroneMedicationRepository(DronesApiContext context) : base(context) { }

        public DroneMedication LoadDroneWithMedication(DroneMedication droneMedication)
        {
            var droneMed = Add(droneMedication);
            return droneMed;
        }
    }
}
