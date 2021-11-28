using drones_api.Services.Contracts;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Services.Implementations
{
    public class LogRepository : ILogRepository
    {
        private readonly IRepositoryManager _repository;
        private readonly ILogger<LogRepository> _logger;
        public LogRepository(IRepositoryManager repositoryManager,
            ILogger<LogRepository> logger)
        {
            _repository = repositoryManager;
            _logger = logger;
        }

        public void LogDroneBatteryLevel()
        {
            var batteryLevels = _repository.Drone.GetAllDroneBatteryLevels();
            _logger.LogWarning($"{JsonConvert.SerializeObject(batteryLevels)}");
        }
    }
}
