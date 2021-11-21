using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Dtos.Response
{
    public class HealthReportResponseDto
    {
        public Boolean Status { get; }
        public TimeSpan TotalDuration { get; }
    }
}
