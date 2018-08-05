using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Exceptions;
using System;

namespace ShyneeBackend.Domain.Entities
{
    public class ShyneeProfile
    {
        private const string _defaultNickname = "Stranger";

        public ShyneeProfile(
            ShyneeProfileParameter<string> nickname,
            ShyneeProfileParameter<Uri> avatarUri, 
            ShyneeProfileParameter<string> name, 
            ShyneeProfileParameter<DateTime> dob, 
            ShyneeProfileParameter<Gender> gender, 
            ShyneeProfileParameter<string[]> interests, 
            ShyneeProfileParameter<string> personalInfo)
        {
            if (nickname.Status == ShyneeProfileParameterStatus.Empty)
                throw new ShyneeProfileNicknameIsEmptyException();

            Nickname = nickname;
            AvatarUri = avatarUri;
            Name = name;
            Dob = dob;
            Gender = gender;
            Interests = interests;
            PersonalInfo = personalInfo;
        }

        public ShyneeProfileParameter<string> Nickname { get; }

        public ShyneeProfileParameter<Uri> AvatarUri { get; }

        public ShyneeProfileParameter<string> Name { get; }

        public ShyneeProfileParameter<DateTime> Dob { get; }

        public ShyneeProfileParameter<Gender> Gender { get; }

        public ShyneeProfileParameter<string[]> Interests { get; }

        public ShyneeProfileParameter<string> PersonalInfo { get; }

        public ShyneeProfilePublicData GeneratePublicShyneeProfile()
        {
            var publicShyneeProfile = new ShyneeProfilePublicData(
                Nickname.Status == ShyneeProfileParameterStatus.Hidden ? 
                    _defaultNickname : Nickname.Parameter,
                AvatarUri.Status == ShyneeProfileParameterStatus.Visible ? 
                    AvatarUri.Parameter.ToString() : null,
                Name.Status == ShyneeProfileParameterStatus.Visible ? 
                    Name.Parameter : null,
                Dob.Status == ShyneeProfileParameterStatus.Visible ? 
                    (DateTime?)Dob.Parameter : null,
                Gender.Status == ShyneeProfileParameterStatus.Visible ? 
                    (Gender?)Gender.Parameter : null,
                Interests.Status == ShyneeProfileParameterStatus.Visible ? 
                    Interests.Parameter : null,
                PersonalInfo.Status == ShyneeProfileParameterStatus.Visible ? 
                    PersonalInfo.Parameter : null);
            return publicShyneeProfile;
        } 
    }
}
