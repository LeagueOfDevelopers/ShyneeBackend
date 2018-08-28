using System;

namespace ShyneeBackend.Domain.DTOs
{
    public class ShyneeProfile
    {
        public ShyneeProfile(
            Guid id,
            ShyneeProfileParameter<string> nickname, 
            ShyneeProfileParameter<Uri> avatarUri, 
            ShyneeProfileParameter<string> name, 
            ShyneeProfileParameter<DateTime> dob, 
            ShyneeProfileParameter<Gender> gender, 
            ShyneeProfileParameter<string[]> interests, 
            ShyneeProfileParameter<string> personalInfo)
        {
            Id = id;
            Nickname = nickname;
            AvatarUri = avatarUri;
            Name = name;
            Dob = dob;
            Gender = gender;
            Interests = interests;
            PersonalInfo = personalInfo;
        }

        public Guid Id { get; }

        public ShyneeProfileParameter<string> Nickname { get; }

        public ShyneeProfileParameter<Uri> AvatarUri { get; }

        public ShyneeProfileParameter<string> Name { get; }

        public ShyneeProfileParameter<DateTime> Dob { get; }

        public ShyneeProfileParameter<Gender> Gender { get; }

        public ShyneeProfileParameter<string[]> Interests { get; }

        public ShyneeProfileParameter<string> PersonalInfo { get; }
    }
}
