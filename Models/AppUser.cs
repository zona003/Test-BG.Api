using Microsoft.AspNetCore.Identity;

namespace AuthServer.Models
{
    public class AppUser : IdentityUser<long>
    {
        public int Id {  get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpireTime { get; set; }
    }
}
