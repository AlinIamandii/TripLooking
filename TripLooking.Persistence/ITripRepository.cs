using System;
using System.Threading.Tasks;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence
{
    public interface ITripRepository
    {
        Task<Trip> GetTripById(Guid id);
    }
}