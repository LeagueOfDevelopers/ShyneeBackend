using System;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.Entities
{
    class ShyneeProfile
    {
        public ShyneeProfile(
            KeyValuePair<bool, string> nickname, 
            KeyValuePair<bool, string> avatarUri, 
            KeyValuePair<bool, string> name, 
            KeyValuePair<bool, DateTime> dob, 
            KeyValuePair<bool, SexType> sex, 
            KeyValuePair<bool, string[]> interests, 
            KeyValuePair<bool, string> personalInfo)
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
        /// Key defines parameter privacy
        /// Shynee nickname (required)
        /// </summary>
        public KeyValuePair<bool, string> Nickname { get; }

        /// <summary>
        /// Key defines parameter privacy
        /// Shynee avatar uri
        /// </summary>
        public KeyValuePair<bool, string> AvatarUri { get; }

        /// <summary>
        /// Key defines parameter privacy
        /// Shynee name
        /// </summary>
        public KeyValuePair<bool, string> Name { get; }

        /// <summary>
        /// Key defines parameter privacy
        /// Shynee date of birthday
        /// </summary>
        public KeyValuePair<bool, DateTime> Dob { get; }

        /// <summary>
        /// Key defines parameter privacy
        /// Shynee sex: male / female / other
        /// </summary>
        public KeyValuePair<bool, SexType> Sex { get; }

        /// <summary>
        /// Key defines parameter privacy
        /// Shynee interests
        /// </summary>
        public KeyValuePair<bool, string[]> Interests { get; }

        /// <summary>
        /// Key defines parameter privacy
        /// Shynee personal information
        /// </summary>
        public KeyValuePair<bool, string> PersonalInfo { get; }
    }
}
