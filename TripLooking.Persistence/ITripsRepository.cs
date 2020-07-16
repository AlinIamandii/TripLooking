using System;
using System.Threading.Tasks;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence
{
    public interface ITripsRepository
    {
        Task<Trip> GetTripById(Guid id);

        Task Create(Trip entity);

        void Update(Trip entity);

        Task SaveChanges();
    }
}
