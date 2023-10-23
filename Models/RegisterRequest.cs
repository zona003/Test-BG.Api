using System.ComponentModel.DataAnnotations;

namespace AuthServer.Models
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required] 
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-18);
        public string Address { get; set; }

    }
}
