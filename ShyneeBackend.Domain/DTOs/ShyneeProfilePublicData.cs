using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeProfilePublicData
    {
        public ShyneeProfilePublicData(
            string nickname, 
            string avatarUri = null, 
            string name = null, 
            DateTime? dob = null, 
            Gender? gender = null, 
            string[] interests = null,
            string personalInfo = null)
        {
            Nickname = nickname;
            AvatarUri = avatarUri;
            Name = name;
            Dob = dob;
            Gender = gender;
            Interests = interests;
            PersonalInfo = personalInfo;
        }

        public string Nickname { get; }

        public string AvatarUri { get; }

        public string Name { get; }

        /// <summary>
        ///  Date of birthday
        /// </summary>
        public DateTime? Dob { get; }

        public Gender? Gender { get; }

        public string[] Interests { get; }

        public string PersonalInfo { get; }
    }
}
