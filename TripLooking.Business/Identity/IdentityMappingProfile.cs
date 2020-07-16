using AutoMapper;

using TripLooking.Business.Identity.Models;
using TripLooking.Entities.Identity;

namespace TripLooking.Business.Identity
{
    public class IdentityMappingProfile : Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}