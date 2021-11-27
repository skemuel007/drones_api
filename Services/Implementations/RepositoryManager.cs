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
        private IDroneMedicationRepository _droneMedicationRepository;
        private IMedicationRepository _medicationRepository;
        
        public RepositoryManager(DronesApiContext context)
        {
            _repositoryContext = context;
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
        public IDroneMedicationRepository DroneMedication
        {
            get
            {
                if (_droneMedicationRepository == null)
                {
                    _droneMedicationRepository = new DroneMedicationRepository(_repositoryContext);
                }

                return _droneMedicationRepository;

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
