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
            ShyneeProfileParameter<Uri> avatarUri = null, 
            ShyneeProfileParameter<string> name = null, 
            ShyneeProfileParameter<DateTime> dob = null, 
            ShyneeProfileParameter<Gender> gender = null, 
            ShyneeProfileParameter<string[]> interests = null, 
            ShyneeProfileParameter<string> personalInfo = null)
        {
            if (nickname.Status == ShyneeProfileParameterStatus.Empty)
                throw new ShyneeProfileNicknameIsEmptyException();

            Nickname = nickname;

            AvatarUri = avatarUri ?? new ShyneeProfileParameter<Uri>(); 
            Name = name ?? new ShyneeProfileParameter<string>();
            Dob = dob ?? new ShyneeProfileParameter<DateTime>();
            Gender = gender ?? new ShyneeProfileParameter<Gender>();
            Interests = interests ?? new ShyneeProfileParameter<string[]>();
            PersonalInfo = personalInfo ?? new ShyneeProfileParameter<string>();
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
