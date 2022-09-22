using System.ComponentModel.DataAnnotations;

namespace Task4AuthWebApp.Models
{
    public class SignInViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
