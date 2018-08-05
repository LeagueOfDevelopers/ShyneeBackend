namespace ShyneeBackend.Domain.Entities
{
    public class ShyneeProfile
    {
        public ShyneeProfile(
            ShyneeProfileParameter nickname,
            ShyneeProfileParameter avatarUri, 
            ShyneeProfileParameter name, 
            ShyneeProfileParameter dob, 
            ShyneeProfileParameter gender, 
            ShyneeProfileParameter interests, 
            ShyneeProfileParameter personalInfo)
        {
            Nickname = nickname;
            AvatarUri = avatarUri;
            Name = name;
            Dob = dob;
            Gender = gender;
            Interests = interests;
            PersonalInfo = personalInfo;
        }

        public ShyneeProfileParameter Nickname { get; }

        public ShyneeProfileParameter AvatarUri { get; }

        public ShyneeProfileParameter Name { get; }

        /// <summary>
        ///  Date of birthday
        /// </summary>
        public ShyneeProfileParameter Dob { get; }

        public ShyneeProfileParameter Gender { get; }

        public ShyneeProfileParameter Interests { get; }

        public ShyneeProfileParameter PersonalInfo { get; }
    }
}
