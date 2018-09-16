using ShyneeBackend.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShyneeBackend.Application.RequestModels
{
    public class EditedShyneeProfile
    {
        [Required]
        public string Nickname { get; set; }

        public Uri AvatarUri { get; set; }

        public string Name { get; set; }

        public DateTime Dob { get; set; }

        public Gender Gender { get; set; }

        public string[] Interests { get; set; }

        public string PersonalInfo { get; set; }
    }
}
