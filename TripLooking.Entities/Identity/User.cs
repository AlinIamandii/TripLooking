using System.ComponentModel.DataAnnotations;

namespace TripLooking.Entities.Identity
{
    public sealed class User : Entity
    {
        public User(string fullName, string email, string passwordHash) 
            : base()
        {
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
        }

        [Required]
        public string FullName { get; private set; }

        [Required]
        public string Email { get; private set; }

        [Required]
        public string PasswordHash { get; private set; }
    }
}
