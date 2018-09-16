using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Exceptions;
using System;

namespace ShyneeBackend.Domain.Entities
{
    public class ShyneeProfile
    {
        private const string _defaultNickname = "Stranger";

        public ShyneeProfile(
            string nickname,
            Uri avatarUri,
            string name,
            DateTime? dob,
            Gender? gender,
            string[] interests,
            string personalInfo)
        {
            Nickname = 
                nickname != null ? 
                new ShyneeProfileParameter<string>(
                        ShyneeProfileParameterStatus.Hidden, 
                        nickname) :
                    new ShyneeProfileParameter<string>(
                        ShyneeProfileParameterStatus.Hidden,
                        _defaultNickname);

            AvatarUri =
                avatarUri != null ?
                    new ShyneeProfileParameter<Uri>(
                        ShyneeProfileParameterStatus.Hidden, 
                        avatarUri) :
                    new ShyneeProfileParameter<Uri>();
            Name = 
                name != null ?
                    new ShyneeProfileParameter<string>(
                        ShyneeProfileParameterStatus.Hidden,
                        name) :
                    new ShyneeProfileParameter<string>();
            Dob =
                dob != null ?
                    new ShyneeProfileParameter<DateTime>(
                        ShyneeProfileParameterStatus.Hidden,
                        (DateTime)dob) :
                    new ShyneeProfileParameter<DateTime>();
            Gender =
                gender != null ?
                    new ShyneeProfileParameter<Gender>(
                        ShyneeProfileParameterStatus.Hidden,
                        (Gender)gender) :
                    new ShyneeProfileParameter<Gender>();
            Interests =
                interests != null ?
                    new ShyneeProfileParameter<string[]>(
                        ShyneeProfileParameterStatus.Hidden,
                        interests) :
                    new ShyneeProfileParameter<string[]>();
            PersonalInfo =
                personalInfo != null ?
                    new ShyneeProfileParameter<string>(
                        ShyneeProfileParameterStatus.Hidden,
                        personalInfo) :
                    new ShyneeProfileParameter<string>();
        }

        public ShyneeProfile(
            ShyneeProfileParameter<string> nickname = null,
            ShyneeProfileParameter<Uri> avatarUri = null, 
            ShyneeProfileParameter<string> name = null, 
            ShyneeProfileParameter<DateTime> dob = null, 
            ShyneeProfileParameter<Gender> gender = null, 
            ShyneeProfileParameter<string[]> interests = null, 
            ShyneeProfileParameter<string> personalInfo = null)
        {
            Nickname = nickname ?? new ShyneeProfileParameter<string>(
                ShyneeProfileParameterStatus.Hidden,
                _defaultNickname);

            if (Nickname.Status == ShyneeProfileParameterStatus.Empty)
                throw new ShyneeProfileNicknameIsEmptyException();

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

        public ShyneeProfileDto GeneratePublicShyneeProfile()
        {
            var publicShyneeProfile = new ShyneeProfileDto(
                Nickname.Status == ShyneeProfileParameterStatus.Hidden ? 
                    _defaultNickname : Nickname.Parameter,
                AvatarUri.Status == ShyneeProfileParameterStatus.Visible ? 
                    AvatarUri.Parameter : null,
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

        public ShyneeProfileFieldsPrivacyDto GenerateProfileFieldsBoolValues()
        {
            var shyneeProfileFieldsPrivacy = new ShyneeProfileFieldsPrivacyDto(
                Nickname.Status == ShyneeProfileParameterStatus.Visible ?
                    true : false,
                AvatarUri.Status == ShyneeProfileParameterStatus.Visible ?
                    true : false,
                Name.Status == ShyneeProfileParameterStatus.Visible ?
                    true : false,
                Dob.Status == ShyneeProfileParameterStatus.Visible ?
                    true : false,
                Gender.Status == ShyneeProfileParameterStatus.Visible ?
                    true : false,
                Interests.Status == ShyneeProfileParameterStatus.Visible ?
                    true : false,
                PersonalInfo.Status == ShyneeProfileParameterStatus.Visible ?
                    true : false);
            return shyneeProfileFieldsPrivacy;
        }
    }
}
