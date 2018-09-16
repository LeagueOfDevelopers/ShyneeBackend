namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeProfileFieldsPrivacyDto
    {
        public ShyneeProfileFieldsPrivacyDto(
            bool nickname, 
            bool avatarUri, 
            bool name, 
            bool dob, 
            bool gender, 
            bool interests, 
            bool personalInfo)
        {
            Nickname = nickname;
            AvatarUri = avatarUri;
            Name = name;
            Dob = dob;
            Gender = gender;
            Interests = interests;
            PersonalInfo = personalInfo;
        }

        public bool Nickname { get; }

        public bool AvatarUri { get; }

        public bool Name { get; }

        public bool Dob { get; }

        public bool Gender { get; }

        public bool Interests { get; }

        public bool PersonalInfo { get; }
    }
}
