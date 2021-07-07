using System;
using System.Threading.Tasks;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence
{
    public class TripsRepository : ITripsRepository
    {
        private TripsContext context;

        public TripsRepository(TripsContext context)
        {
            this.context = context;
        }

        public async Task<Trip> GetTripById(Guid id)
        {
            return await this.context.Trips.FindAsync(id);
        }
    }
}