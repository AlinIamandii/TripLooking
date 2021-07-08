using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Photos;

namespace TripLooking.Business.Trips.Services.Photos
{
    public interface IPhotosService
    {
        Task<PhotoModel> Add(Guid tripId, CreatePhotoModel model);

        Task<PhotoModel> GetById(Guid tripId, Guid photoId);

        Task<IEnumerable<PhotoModel>> Get(Guid tripId);
    }
}