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
        private IDroneRepository _droneRepository;
        private IMedicationRepository _medicationRepository;
        private IDroneRequestRepository _droneRequestRepository;
        private IDroneItemRepository _droneItemRepository;
        
        public RepositoryManager(DronesApiContext context)
        {
            _repositoryContext = context;
        }
        
        public IDroneItemRepository DroneItem
        {
            get
            {
                if (_droneItemRepository == null )
                {
                    _droneItemRepository = new DroneItemRepository(_repositoryContext);
                }

                return _droneItemRepository;
            }
        }
        public IMedicationRepository Medication
        {
            get
            {
                if (_medicationRepository == null)
                {
                    _medicationRepository = new MedicationRepository(_repositoryContext);
                }

                return _medicationRepository;

            }
        }

        public IDroneRequestRepository DroneRequest
        {
            get
            {
                if (_droneRequestRepository == null)
                {
                    _droneRequestRepository = new DroneRequestRepository(_repositoryContext);
                }

                return _droneRequestRepository;

            }
        }
        public IDroneRepository Drone
        {
            get
            {
                if (_droneRepository == null )
                {
                    _droneRepository = new DroneRepository(_repositoryContext);
                }

                return _droneRepository;

            }
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
