namespace TripLooking.Business.Identity.Services.Interfaces
{
    public interface IPasswordHasher
    {
        string CreateHash(string password);

        bool Check(string hash, string password);
    }
}
