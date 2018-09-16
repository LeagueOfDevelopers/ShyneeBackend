using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShyneeBackend.Domain.Services
{
    public class ShyneesService : IShyneesService
    {
        private readonly IShyneesRepository _shyneesRepository;
        private readonly ApplicationSettings _applicationSettings;

        public ShyneesService(
            IShyneesRepository shyneesRepository,
            ApplicationSettings applicationSettings)
        {
            _shyneesRepository = shyneesRepository;
            _applicationSettings = applicationSettings;
        }

        public ShyneeProfileDto GetShyneeProfile(Guid id)
        {
            var shyneeProfile = _shyneesRepository.GetShynee(id).Profile;
            var shyneeProfileDto = new ShyneeProfileDto(
                shyneeProfile.Nickname.Parameter,
                shyneeProfile.AvatarUri.Parameter,
                shyneeProfile.Name.Parameter,
                shyneeProfile.Dob.Parameter,
                shyneeProfile.Gender.Parameter,
                shyneeProfile.Interests.Parameter,
                shyneeProfile.PersonalInfo.Parameter);
            return shyneeProfileDto;
        }

        public ShyneeProfileDto UpdateShyneeProfile(
            Guid id,
            ShyneeProfile profile)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            shynee.UpdateProfile(profile);
            _shyneesRepository.UpdateShynee(shynee);
            return new ShyneeProfileDto(
                profile.Nickname.Parameter,
                profile.AvatarUri.Parameter,
                profile.Name.Parameter,
                profile.Dob.Parameter,
                profile.Gender.Parameter,
                profile.Interests.Parameter,
                profile.PersonalInfo.Parameter);
        }

        public ShyneeProfileDto GetShyneePublicData(Guid id)
        {
            var shyneeProfile = _shyneesRepository.GetShynee(id).Profile;
            var shyneeProfileDto = shyneeProfile.GeneratePublicShyneeProfile();
            return shyneeProfileDto;
        }

        public ShyneeSettingsDto GetShyneeSettings(Guid id)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            var shyneeSettings = shynee.Settings;
            var settings = new ShyneeSettingsDto(
                shyneeSettings.BackgroundModeIsEnabled,
                shyneeSettings.MetroModeIsEnabled,
                shyneeSettings.PushNotificationsAreEnabled,
                shyneeSettings.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                shyneeSettings.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                shyneeSettings.PushNotificationOnNewAcquaintanceIsEnabled);
            return settings;
        }

        public ShyneeIsReadySettingDto ChangeShyneeReadySetting(Guid id, bool isReady)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            shynee.Settings.UpdateIsReadySetting(isReady);
            var updatedShynee = _shyneesRepository.UpdateShynee(shynee);
            var shyneeIsReady = new ShyneeIsReadySettingDto(
                updatedShynee.Settings.IsReady);
            return shyneeIsReady;
        }

        public IEnumerable<ShyneeAroundDto> GetShyneesAroundList(
            ShyneeCoordinates shyneeCoordinates)
        {
            var shyneesAroundListInfos = _shyneesRepository.GetShynees()
                .Where(s => s.Coordinates.CalculateDistance(
                    shyneeCoordinates.Latitude,
                    shyneeCoordinates.Longitude) <= _applicationSettings.RadiusAround)
                .Select(s =>
                {
                    var publicProfile = s.Profile.GeneratePublicShyneeProfile();
                    return new ShyneeAroundDto(s.Id,
                        publicProfile.Nickname,
                        publicProfile.AvatarUri);
                });
            return shyneesAroundListInfos;
        }

        public Shynee GetShynee(Guid id)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            return shynee;
        }

        public Shynee CreateShynee(
            ShyneeCredentials shyneeCredentials,
            ShyneeProfile shyneeProfile)
        {
            if (_shyneesRepository.IsShyneeExists(shyneeCredentials.Email))
                throw new ShyneeDuplicateException();
            var shynee = new Shynee(
                shyneeCredentials,
                new ShyneeCoordinates(),
                shyneeProfile,
                new ShyneeSettings());
            var id = _shyneesRepository.CreateShynee(shynee);
            var createdShynee = _shyneesRepository.GetShynee(id);
            return createdShynee;
        }

        public ShyneeSettingsDto UpdateShyneeSettings(
            Guid id, 
            ShyneeSettings settings)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            var settingsToUpdate = new ShyneeSettings(
                shynee.Settings.IsReady,
                settings.BackgroundModeIsEnabled,
                settings.MetroModeIsEnabled,
                settings.PushNotificationsAreEnabled,
                settings.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                settings.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                settings.PushNotificationOnNewAcquaintanceIsEnabled);
            shynee.UpdateSettings(settingsToUpdate);
            var updatedShynee = _shyneesRepository.UpdateShynee(shynee);
            var updatedSettings = updatedShynee.Settings;
            var shyneeSettings = new ShyneeSettingsDto(
                updatedSettings.BackgroundModeIsEnabled,
                updatedSettings.MetroModeIsEnabled,
                updatedSettings.PushNotificationsAreEnabled,
                updatedSettings.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                updatedSettings.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                updatedSettings.PushNotificationOnNewAcquaintanceIsEnabled);
            return shyneeSettings;
        }

        public Shynee FindShyneeByCredentials(ShyneeCredentials credentials)
        {
            var shynee = _shyneesRepository.FindShyneeByCredentials(credentials);
            return shynee;
        }

        public ShyneeProfileFieldsPrivacyDto UpdateShyneeProfileFieldsPrivacy(
            Guid id, 
            ShyneeProfileFieldsPrivacyDto fieldsPrivacy)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            var shyneeProfile = shynee.Profile;
            var shyneeProfileToUpdate = new ShyneeProfile(
                new ShyneeProfileParameter<string>(
                    fieldsPrivacy.Nickname,
                    shyneeProfile.Nickname.Parameter),
                new ShyneeProfileParameter<Uri>(
                    fieldsPrivacy.AvatarUri,
                    shyneeProfile.AvatarUri.Parameter),
                new ShyneeProfileParameter<string>(
                    fieldsPrivacy.Name,
                    shyneeProfile.Name.Parameter),
                new ShyneeProfileParameter<DateTime>(
                    fieldsPrivacy.Dob,
                    shyneeProfile.Dob.Parameter),
                new ShyneeProfileParameter<Gender>(
                    fieldsPrivacy.Gender,
                    shyneeProfile.Gender.Parameter),
                new ShyneeProfileParameter<string[]>(
                    fieldsPrivacy.Interests,
                    shyneeProfile.Interests.Parameter),
                new ShyneeProfileParameter<string>(
                    fieldsPrivacy.PersonalInfo,
                    shyneeProfile.PersonalInfo.Parameter));
            shynee.UpdateProfile(shyneeProfileToUpdate);
            _shyneesRepository.UpdateShynee(shynee);
            return fieldsPrivacy;
        }

        public ShyneeProfileFieldsPrivacyDto GetShyneeProfileFieldsPrivacy(
            Guid id)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            var shyneeProfileFieldsPrivacyDto = shynee.Profile
                .GenerateProfileFieldsBoolValues();
            return shyneeProfileFieldsPrivacyDto;
        }
    }
}
