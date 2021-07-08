using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models;

namespace TripLooking.Business.Trips.Services
{
    public interface ITripsService
    {
        IEnumerable<TripModel> GetAll();

        Task<TripModel> GetById(Guid id);

        Task<TripModel> Create(UpsertTripModel model);

        Task Delete(Guid tripId);

        Task Update(Guid tripId, UpsertTripModel model);
    }
}