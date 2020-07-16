using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Photo;

namespace TripLooking.Business.Trips.Services.Interfaces
{
    public interface IPhotosService
    {
        Task<PhotoModel> Add(Guid tripId, CreatePhotoModel model);

        Task<PhotoModel> GetById(Guid tripId, Guid photoId);

        Task<IEnumerable<PhotoModel>> Get(Guid tripId);
    }
}