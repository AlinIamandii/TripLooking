using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Entities.Trips;

namespace TripLooking.Business.Trips
{
    public sealed class TripsMappingProfiles : Profile
    {
        public TripsMappingProfiles()
        {
            CreateMap<Trip, TripModel>();

            CreateMap<Comment, CommentModel>();
        }
    }
}
