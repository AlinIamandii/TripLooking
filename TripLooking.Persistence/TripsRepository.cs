using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence
{
    public class TripsRepository : ITripsRepository
    {
        private readonly TripsContext _context;

        public TripsRepository(TripsContext context)
        {
            _context = context;
        }

        public IEnumerable<Trip> GetAll()
        {
            return _context.Trips;
        }

        public async Task<Trip> GetTripById(Guid id)
        {
            return await _context.Trips
                .Include(x => x.Comments)
                .Include(x => x.Photos)
                .FirstAsync(i => i.Id == id);
        }

        public async Task Create(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
        }

        public void Update(Trip trip)
        {
            _context.Trips.Update(trip);
        }

        public void Delete(Trip trip)
        {
            _context.Trips.Remove(trip);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}