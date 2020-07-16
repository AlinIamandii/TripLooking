using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqBuilder.Core;
using TripLooking.Entities.Trips;

namespace TripLooking.Persistence.Trips
{
    public interface ITripsRepository : IRepository<Trip>
    {
        Task<IList<Trip>> Get(ISpecification<Trip> spec);

        Task<int> CountAsync();

        Task<Trip> GetByIdWithPhotos(Guid id);
        
        Task<Trip> GetByIdWithComments(Guid id);
    }
}