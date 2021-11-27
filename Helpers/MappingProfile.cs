using AutoMapper;
using drones_api.Dtos.Request;
using drones_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DroneModelCreateDto, DroneModel>();
            CreateMap<DroneStateCreateDto, DroneState>();
            CreateMap<DroneModelUpdateDto, DroneModel>();
            CreateMap<DroneStateUpdateDto, DroneState>();
            CreateMap<DroneCreateDto, Drone>();
        }
    }
}
