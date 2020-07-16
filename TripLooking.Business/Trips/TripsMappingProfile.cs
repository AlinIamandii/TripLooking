using AutoMapper;

using TripLooking.Business.Trips.Models.Comment;
using TripLooking.Business.Trips.Models.Photo;
using TripLooking.Business.Trips.Models.Trip;
using TripLooking.Entities.Trips;

namespace TripLooking.Business.Trips
{
    public class TripsMappingProfile : Profile
    {
        public TripsMappingProfile()
        {
            CreateMap<UpsertTripModel, Trip>();
            CreateMap<Trip, TripModel>();

            CreateMap<CreateCommentModel, Comment>();
            CreateMap<Comment, CommentModel>();

            CreateMap<PhotoModel, Photo>();
            CreateMap<Photo, PhotoModel>();
        }
    }
}