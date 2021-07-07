using System;
using AutoMapper;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Entities.Trips;

namespace TripLooking.Business.Trips
{
    public sealed class TripsMappingProfile : Profile
    {
        public TripsMappingProfile()
        {
            CreateMap<Trip, TripModel>();

            CreateMap<CreateTripModel, Trip>();

            CreateMap<CreateCommentModel, Comment>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<Comment, CommentModel>();
        }
    }
}
