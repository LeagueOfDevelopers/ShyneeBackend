using ShyneeBackend.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShyneeBackend.Application.RequestModels
{
    public class EditedShyneeProfile
    {
        [Required]
        public string Nickname { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Format: YYYY-MM-DD
        /// </summary>
        public DateTime? Dob { get; set; }

        public Gender Gender { get; set; }

        public string[] Interests { get; set; }

        public string PersonalInfo { get; set; }
    }
}
