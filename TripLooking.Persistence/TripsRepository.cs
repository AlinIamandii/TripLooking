using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TripLooking.Entities.Trips;

namespace TripLooking.Persistence
{
    public sealed class TripsRepository : ITripsRepository
    {
        private readonly TripsContext context;

        public TripsRepository(TripsContext context)
        {
            this.context = context;
        }

        public async Task<Trip> GetTripById(Guid id)
        {
            IQueryable<Trip> test = context.Trips;
            return test.Where(x => x.Id == id).FirstOrDefault();
            //return await this.context.Trips.FindAsync(id);
        }
    }
}
