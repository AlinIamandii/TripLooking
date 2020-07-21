using System.Threading.Tasks;

using TripLooking.Business.Identity.Models;

namespace TripLooking.Business.Identity.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest userAuthenticationModel);

        Task<UserModel> Register(UserRegisterModel userRegisterModel);
    }
}
