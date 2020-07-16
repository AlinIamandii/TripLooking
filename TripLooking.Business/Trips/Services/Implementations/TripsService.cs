using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using TripLooking.Business.Trips.Extensions;
using TripLooking.Business.Trips.Models.Trip;
using TripLooking.Business.Trips.Services.Interfaces;
using TripLooking.Entities.Trips;
using TripLooking.Persistence.Trips;

namespace TripLooking.Business.Trips.Services.Implementations
{
    public sealed class TripsService : ITripsService
    {
        private readonly ITripsRepository _repository;
        private readonly IMapper _mapper;

        public TripsService(ITripsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TripModel> Add(UpsertTripModel model)
        {
            var trip = _mapper.Map<Trip>(model);

            await _repository.Add(trip);
            await _repository.SaveChanges();

            return _mapper.Map<TripModel>(trip);
        }

        public async Task<PaginatedList<TripModel>> Get(SearchModel model)
        {
            var spec = model.ToSpecification<Trip>();

            var entities = await _repository.Get(spec);
            var count = await _repository.CountAsync();

            return new PaginatedList<TripModel>(
                model.PageIndex, 
                entities.Count, 
                count,
                _mapper.Map<IList<TripModel>>(entities));
        }

        public async Task<TripModel> GetById(Guid id)
        {
            var entity = await _repository.GetById(id);

            var trip = _mapper.Map<TripModel>(entity);
            return trip;
        }

        public async Task Update(Guid id, UpsertTripModel model)
        {
            var trip = await _repository.GetById(id);

            trip.Update(model.Title, model.Description, model.Private);

            _repository.Update(trip);
            await _repository.SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            var trip = await _repository.GetById(id);

            _repository.Delete(trip);
            await _repository.SaveChanges();
        }
    }
}