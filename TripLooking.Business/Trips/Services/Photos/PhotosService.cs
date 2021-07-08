using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TripLooking.Business.Trips.Models.Photos;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;

namespace TripLooking.Business.Trips.Services.Photos
{
    public sealed class PhotosService : IPhotosService
    {
        private readonly IMapper _mapper;
        private readonly ITripsRepository _tripsRepository;

        public PhotosService(ITripsRepository tripsRepository, IMapper mapper)
        {
            _tripsRepository = tripsRepository;
            _mapper = mapper;
        }

        public async Task<PhotoModel> Add(Guid tripId, CreatePhotoModel model)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            using var stream = new MemoryStream();
            await model.Content.CopyToAsync(stream);

            var photo = new Photo(model.Content.FileName, stream.ToArray());
            trip.Photos.Add(photo);

            _tripsRepository.Update(trip);

            await _tripsRepository.SaveChanges();

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<PhotoModel> GetById(Guid tripId, Guid photoId)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            var photo = trip.Photos.FirstOrDefault(p => p.Id == photoId);

            return _mapper.Map<PhotoModel>(photo);
        }

        public async Task<IEnumerable<PhotoModel>> Get(Guid tripId)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            return _mapper.Map<IEnumerable<PhotoModel>>(trip.Photos);
        }
    }
}