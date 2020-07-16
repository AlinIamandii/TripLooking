using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TripLooking.Business.Trips.Models;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;

namespace TripLooking.Business.Trips.Services
{
    public sealed class TripsService : ITripsService
    {
        private readonly ITripsRepository repository;
        private readonly IMapper mapper;

        public TripsService(ITripsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<TripModel> GetById(Guid id)
        {
            var trip = await repository.GetTripById(id);

            return mapper.Map<TripModel>(trip);
        }

        public async Task<TripModel> Create(CreateTripModel model)
        {
            var trip = new Trip(model.Title, model.Description, model.Private);

            await repository.Create(trip);
            await repository.SaveChanges();

            return mapper.Map<TripModel>(trip);
        }
    }
}
