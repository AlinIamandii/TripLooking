using Microsoft.AspNetCore.Http;

namespace TripLooking.Business.Trips.Models.Photo
{
    public sealed class CreatePhotoModel
    {
        public IFormFile Content { get; set; }
    }
}