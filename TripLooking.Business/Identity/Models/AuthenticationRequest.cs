namespace TripLooking.Business.Identity.Models
{
    public sealed class AuthenticationRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
