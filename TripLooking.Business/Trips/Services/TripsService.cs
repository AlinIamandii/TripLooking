using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TripLooking.Business.Trips.Models;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;

namespace TripLooking.Business.Trips.Services
{
    public sealed class TripsService : ITripsService
    {
        private readonly ITripsRepository _tripsRepository;
        private readonly IMapper _mapper;

        public TripsService(ITripsRepository tripsRepository, IMapper mapper)
        {
            _tripsRepository = tripsRepository;
            _mapper = mapper;
        }

        public IEnumerable<TripModel> GetAll()
        {
            var trips = _tripsRepository.GetAll();

            return _mapper.Map<IEnumerable<TripModel>>(trips);
        }

        public async Task<TripModel> GetById(Guid id)
        {
            var trip = await _tripsRepository.GetTripById(id);

            return _mapper.Map<TripModel>(trip);
        }

        public async Task<TripModel> Create(UpsertTripModel model)
        {
            var trip = _mapper.Map<Trip>(model);

            await _tripsRepository.Create(trip);
            await _tripsRepository.SaveChanges();

            return _mapper.Map<TripModel>(trip);
        }

        public async Task Delete(Guid tripId)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            _tripsRepository.Delete(trip);
            await _tripsRepository.SaveChanges();
        }

        public async Task Update(Guid tripId, UpsertTripModel model)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            _mapper.Map(model, trip);

            _tripsRepository.Update(trip);
            await _tripsRepository.SaveChanges();
        }
    }
}