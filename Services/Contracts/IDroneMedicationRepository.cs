using drones_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IDroneMedicationRepository
    {
        DroneMedication LoadDroneWithMedication(DroneMedication droneMedication);
    }
}
