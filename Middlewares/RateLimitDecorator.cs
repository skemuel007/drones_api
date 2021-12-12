using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Middlewares
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RateLimitDecorator : Attribute
    {
        public StrategyTypeEnum StrategyType { get; set; }
    }

    public enum StrategyTypeEnum
    {
        IpAddress,
        PerUser,
        PerApiKey
    }
}
