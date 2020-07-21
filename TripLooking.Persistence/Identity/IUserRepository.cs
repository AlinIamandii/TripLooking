using System.Threading.Tasks;
using TripLooking.Entities.Identity;

namespace TripLooking.Persistence.Identity
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
