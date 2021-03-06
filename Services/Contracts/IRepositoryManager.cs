using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Contracts
{
    public interface IRepositoryManager
    {
        IDroneModelRepository DroneModel { get; }
        IDroneStateRepository DroneState { get;  }
        IDroneRepository Drone { get;  }
        IMedicationRepository Medication { get;  }
        IDroneRequestRepository DroneRequest { get; }
        IDroneItemRepository DroneItem { get;  }
    }
}
