using ShyneeBackend.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShyneeBackend.Application.RequestModels
{
    public class EditedShyneeProfile
    {
        [Required]
        public ShyneeProfileParameter<string> Nickname { get; set; }

        [Required]
        public ShyneeProfileParameter<Uri> AvatarUri { get; set; }

        [Required]
        public ShyneeProfileParameter<string> Name { get; set; }

        [Required]
        public ShyneeProfileParameter<DateTime> Dob { get; set; }

        [Required]
        public ShyneeProfileParameter<Gender> Gender { get; set; }

        [Required]
        public ShyneeProfileParameter<string[]> Interests { get; set; }

        [Required]
        public ShyneeProfileParameter<string> PersonalInfo { get; set; }
    }
}
