using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence
{
    public interface ITripsRepository
    {
        IEnumerable<Trip> GetAll();

        Task<Trip> GetTripById(Guid id);

        Task Create(Trip trip);

        void Update(Trip trip);

        void Delete(Trip trip);

        Task SaveChanges();
    }
}