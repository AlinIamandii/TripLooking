using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Trip;

namespace TripLooking.Business.Trips.Services.Interfaces
{
    public interface ITripsService
    {
        Task<TripModel> Add(UpsertTripModel model);

        Task<PaginatedList<TripModel>> Get(SearchModel model);

        Task<TripModel> GetById(Guid id);

        Task Update(Guid id, UpsertTripModel model);

        Task Delete(Guid id);
    }
}