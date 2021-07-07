using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TripLooking.Business.Trips.Models;
using TripLooking.Entities.Trips;

namespace TripLooking.Business.Trips
{
    public sealed class TripsMappingProfile : Profile
    {
        public TripsMappingProfile()
        {
            CreateMap<Trip, TripModel>();
        }
    }
}
