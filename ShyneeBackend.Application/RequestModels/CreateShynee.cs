using ShyneeBackend.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShyneeBackend.Application.RequestModels
{
    public class CreateShynee
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        public string Nickname { get; set; }

        public string AvatarUri { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public Gender Gender { get; set; }

        public string[] Interests { get; set; }

        public string PersonalInfo { get; set; }
    }
}
