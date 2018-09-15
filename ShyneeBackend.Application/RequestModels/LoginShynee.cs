using System.ComponentModel.DataAnnotations;

namespace ShyneeBackend.Application.RequestModels
{
    public class LoginShynee
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
