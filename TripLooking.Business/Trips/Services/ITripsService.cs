using System;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models;

namespace TripLooking.Business.Trips.Services
{
    public interface ITripsService
    {
        Task<TripModel> GetById(Guid id);
    }
}