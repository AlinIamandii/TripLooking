using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using TripLooking.Business.Trips.Models.Photo;
using TripLooking.Business.Trips.Services.Interfaces;
using TripLooking.Entities.Trips;
using TripLooking.Persistence.Trips;

namespace TripLooking.Business.Trips.Services.Implementations
{
    public sealed class PhotosService : IPhotosService
    {
        private readonly IMapper _mapper;
        private readonly ITripsRepository _repository;

        public PhotosService(ITripsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PhotoModel> Add(Guid tripId, CreatePhotoModel model)
        {
            var trip = await _repository.GetById(tripId);

            using var stream = new MemoryStream();
            await model.Content.CopyToAsync(stream);
            var photo = new Photo(model.Content.FileName, stream.ToArray());

            trip.Photos.Add(photo);

            _repository.Update(trip);

            await _repository.SaveChanges();

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<PhotoModel> GetById(Guid tripId, Guid photoId)
        {
            var trip = await _repository.GetByIdWithPhotos(tripId);

            var photo = trip.Photos.FirstOrDefault(p => p.Id == photoId);

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<IEnumerable<PhotoModel>> Get(Guid tripId)
        {
            var trip = await _repository.GetByIdWithPhotos(tripId);

            return _mapper.Map<IEnumerable<PhotoModel>>(trip.Photos);
        }
    }
}