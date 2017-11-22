using demobackend.Data;
using demobackend.Models;
using System.Collections.Generic;
using AutoMapper;
using System;

namespace demobackend.AutoMapperProfile
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        : this("MyProfile")
        {
        }
        protected AutoMapperProfileConfiguration(string profileName)
        : base(profileName)
        {
            CreateMap<Car, CarViewModel>();
            CreateMap<CarViewModel, Car>();
        }
    }
}