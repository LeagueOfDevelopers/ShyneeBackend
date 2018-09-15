using ShyneeBackend.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShyneeBackend.Application.RequestModels
{
    public class EditedShyneeProfile
    {
        [Required]
        public ShyneeProfileParameter<string> Nickname { get; set; }

        public ShyneeProfileParameter<Uri> AvatarUri { get; set; }

        public ShyneeProfileParameter<string> Name { get; set; }

        public ShyneeProfileParameter<DateTime> Dob { get; set; }

        public ShyneeProfileParameter<Gender> Gender { get; set; }
         
        public ShyneeProfileParameter<string[]> Interests { get; set; }

        public ShyneeProfileParameter<string> PersonalInfo { get; set; }
    }
}
