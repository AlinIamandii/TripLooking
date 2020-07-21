using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using Microsoft.EntityFrameworkCore;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence.Trips
{
    public sealed class TripsRepository : Repository<Trip>, ITripsRepository
    {
        public TripsRepository(TripsContext context) : base(context) { }

        public async Task<IList<Trip>> Get(ISpecification<Trip> spec)
            => await this.context.Trips.ExeSpec(spec).ToListAsync();

        public async Task<int> CountAsync()
            => await this.context.Trips.CountAsync();

        public async Task<Trip> GetByIdWithPhotos(Guid id)
            => await this.context.Trips
                .Include(trip => trip.Comments)
                .Include(trip => trip.Photos)
                .FirstAsync(trip => trip.Id == id);

        public async Task<Trip> GetByIdWithComments(Guid id)
            => await this.context.Trips
                .Include(trip => trip.Comments)
                .FirstAsync(trip => trip.Id == id);
    }
}