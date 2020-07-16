using System;
using System.Threading.Tasks;
using TripLooking.Entities;

namespace TripLooking.Persistence
{
    public interface IRepository<T>
        where T : Entity
    {
        Task<T> GetById(Guid id);

        Task Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task SaveChanges();
    }
}