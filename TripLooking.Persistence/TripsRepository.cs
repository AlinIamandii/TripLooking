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
            return await this.context.Trips.FindAsync(id);
        }

        public async Task Create(Trip entity)
        {
            await this.context.Trips.AddAsync(entity);
        }

        public void Update(Trip entity)
        {
            this.context.Trips.Update(entity);
        }

        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}
