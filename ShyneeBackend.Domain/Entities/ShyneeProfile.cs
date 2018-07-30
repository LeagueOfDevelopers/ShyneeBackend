using System;

namespace ShyneeBackend.Domain.Entities
{
    public class ShyneeProfile
    {
        public ShyneeProfile(
            ShyneeProfileParameter nickname,
            ShyneeProfileParameter avatarUri, 
            ShyneeProfileParameter name, 
            ShyneeProfileParameter dob, 
            ShyneeProfileParameter sex, 
            ShyneeProfileParameter interests, 
            ShyneeProfileParameter personalInfo)
        {
            Nickname = nickname;
            AvatarUri = avatarUri;
            Name = name;
            Dob = dob;
            Sex = sex;
            Interests = interests;
            PersonalInfo = personalInfo;
        }

        /// <summary>
        /// Shynee nickname (required)
        /// </summary>
        public ShyneeProfileParameter Nickname { get; }

        /// <summary>
        /// Shynee avatar uri
        /// </summary>
        public ShyneeProfileParameter AvatarUri { get; }

        /// <summary>
        /// Shynee name
        /// </summary>
        public ShyneeProfileParameter Name { get; }

        /// <summary>
        /// Shynee date of birthday
        /// </summary>
        public ShyneeProfileParameter Dob { get; }

        /// <summary>
        /// Shynee sex: male / female / other
        /// </summary>
        public ShyneeProfileParameter Sex { get; }

        /// <summary>
        /// Shynee interests
        /// </summary>
        public ShyneeProfileParameter Interests { get; }

        /// <summary>
        /// Shynee personal information
        /// </summary>
        public ShyneeProfileParameter PersonalInfo { get; }
    }
}
