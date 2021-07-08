using Microsoft.AspNetCore.Http;

namespace TripLooking.Business.Trips.Models.Photos
{
    public class CreatePhotoModel
    {
        public IFormFile Content { get; set; }
    }
}