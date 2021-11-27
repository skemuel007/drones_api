using drones_api.Data;
using drones_api.Models;
using drones_api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class MedicationRepository : RepositoryBase<Medication>, IMedicationRepository
    {
        public MedicationRepository(DronesApiContext context) : base(context) { }

    }
}
