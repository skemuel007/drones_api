using drones_api.Data;
using drones_api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class RepositoryManager : IRepositoryManager
    {
        private DronesApiContext _repositoryContext;
        private IDroneModelRepository _droneModelRepository;
        private IDroneStateRepository _droneStateRepository;
        
        public RepositoryManager(DronesApiContext context)
        {
            _repositoryContext = context;
        }

        public IDroneModelRepository DroneModel
        {
            get
            {
                if (_droneModelRepository == null)
                {
                    _droneModelRepository = new DroneModelRepository(_repositoryContext);
                }

                return _droneModelRepository;
            }
        }

        public IDroneStateRepository DroneState
        {
            get
            {
                if (_droneStateRepository == null)
                {
                    _droneStateRepository = new DroneStateRepository(_repositoryContext);
                }

                return _droneStateRepository;
            }
        }
    }
}
