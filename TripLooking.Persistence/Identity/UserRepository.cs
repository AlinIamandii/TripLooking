using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TripLooking.Entities.Identity;

namespace TripLooking.Persistence.Identity
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        private readonly TripsContext _context;

        public UserRepository(TripsContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email) =>
            await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
    }
}
