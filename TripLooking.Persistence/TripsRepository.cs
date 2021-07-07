using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return await this.context.Trips.Include(x => x.Comments)
                .SingleOrDefaultAsync(i => i.Id == id);
        }

        public async Task Create(Trip trip)
        {
            await this.context.Trips.AddAsync(trip);
        }

        public void Update(Trip trip)
        { 
            this.context.Trips.Update(trip);
        }

        public async Task SaveChanges()
        {
            await this.context.SaveChangesAsync();
        }
    }
}