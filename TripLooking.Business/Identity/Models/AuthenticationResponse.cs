namespace TripLooking.Business.Identity.Models
{
    public sealed class AuthenticationResponse
    {
        public AuthenticationResponse(string fullName, string token, string email)
        {
            FullName = fullName;
            Token = token;
            Email = email;
        }

        public string FullName { get; private set; }

        public string Email { get; private set; }

        public string Token { get; private set; }

    }
}
