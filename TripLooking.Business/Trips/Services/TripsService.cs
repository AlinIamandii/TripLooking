using System;
using System.Threading.Tasks;
using AutoMapper;
using TripLooking.Business.Trips.Models;
using TripLooking.Persistence;

namespace TripLooking.Business.Trips.Services
{
    public sealed class TripsService : ITripsService
    {
        private readonly ITripsRepository tripsRepository;
        private readonly IMapper mapper;

        public TripsService(ITripsRepository tripsRepository, IMapper mapper)
        {
            this.tripsRepository = tripsRepository;
            this.mapper = mapper;
        }

        public async Task<TripModel> GetById(Guid id)
        {
            var trip = await this.tripsRepository.GetTripById(id);

            return mapper.Map<TripModel>(trip);
        }
    }
}