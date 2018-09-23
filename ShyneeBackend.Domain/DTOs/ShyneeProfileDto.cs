using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeProfileDto
    {
        public ShyneeProfileDto(
            string nickname, 
            string avatarUri, 
            string name, 
            DateTime? dob, 
            Gender? gender, 
            string[] interests, 
            string personalInfo)
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

        public DateTime? Dob { get; }

        public Gender? Gender { get; }

        public string[] Interests { get; }

        public string PersonalInfo { get; }
    }
}
