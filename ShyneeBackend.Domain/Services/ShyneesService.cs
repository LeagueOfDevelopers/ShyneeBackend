using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Domain.IServices;
using ShyneeBackend.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<ShyneeProfileDto> GetShyneeProfile(Guid id)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            var shyneeProfile = shynee.Profile;
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

        public async Task<ShyneeProfileDto> UpdateShyneeProfileAsync(
            Guid id,
            ShyneeProfile profile)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            shynee.UpdateProfile(profile);
            await _shyneesRepository.UpdateShyneeAsync(shynee);
            return new ShyneeProfileDto(
                profile.Nickname.Parameter,
                profile.AvatarUri.Parameter,
                profile.Name.Parameter,
                profile.Dob.Parameter,
                profile.Gender.Parameter,
                profile.Interests.Parameter,
                profile.PersonalInfo.Parameter);
        }

        public async Task<ShyneeProfileDto> GetShyneePublicDataAsync(Guid id)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            var shyneeProfileDto = shynee.Profile.GeneratePublicShyneeProfile();
            return shyneeProfileDto;
        }

        public async Task<ShyneeSettingsDto> GetShyneeSettingsAsync(Guid id)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
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

        public async Task<ShyneeIsReadySettingDto> ChangeShyneeReadySettingAsync(Guid id, bool isReady)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            shynee.Settings.UpdateIsReadySetting(isReady);
            var updatedShynee = await _shyneesRepository.UpdateShyneeAsync(shynee);
            var shyneeIsReady = new ShyneeIsReadySettingDto(
                updatedShynee.Settings.IsReady);
            return shyneeIsReady;
        }

        public async Task<IEnumerable<ShyneeAroundDto>> GetShyneesAroundListAsync(
            ShyneeCoordinates shyneeCoordinates)
        {
            var shynees = await _shyneesRepository.GetShyneesAsync();
            var shyneesAroundListInfos = shynees.Where(s => s.Coordinates.CalculateDistance(
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

        public async Task<Shynee> GetShyneeAsync(Guid id)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            return shynee;
        }

        public async Task<Shynee> CreateShyneeAsync(
            ShyneeCredentials shyneeCredentials,
            ShyneeProfile shyneeProfile)
        {
            if (await _shyneesRepository.IsShyneeExistsAsync(shyneeCredentials.Email))
                throw new ShyneeDuplicateException();
            var shynee = new Shynee(
                shyneeCredentials,
                new ShyneeCoordinates(),
                shyneeProfile,
                new ShyneeSettings());
            var id = await _shyneesRepository.CreateShyneeAsync(shynee);
            var createdShynee = await _shyneesRepository.GetShyneeAsync(id);
            return createdShynee;
        }

        public async Task<ShyneeSettingsDto> UpdateShyneeSettingsAsync(
            Guid id, 
            ShyneeSettings settings)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            var settingsToUpdate = new ShyneeSettings(
                shynee.Settings.IsReady,
                settings.BackgroundModeIsEnabled,
                settings.MetroModeIsEnabled,
                settings.PushNotificationsAreEnabled,
                settings.OfferMetroModeActivationWhenNoCoonnectionIsEnabled,
                settings.OfferMetroModeDeactivationWhenCoonnectionIsEnabled,
                settings.PushNotificationOnNewAcquaintanceIsEnabled);
            shynee.UpdateSettings(settingsToUpdate);
            var updatedShynee = await _shyneesRepository.UpdateShyneeAsync(shynee);
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

        public async Task<Shynee> FindShyneeByCredentialsAsync(ShyneeCredentials credentials)
        {
            var shynee = await _shyneesRepository.FindShyneeByCredentialsAsync(credentials);
            return shynee;
        }

        public async Task<ShyneeProfileFieldsPrivacyDto> UpdateShyneeProfileFieldsPrivacyAsync(
            Guid id, 
            ShyneeProfileFieldsPrivacyDto fieldsPrivacy)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            var shyneeProfileToUpdate = new ShyneeProfile(
                new ShyneeProfileParameter<string>(
                    fieldsPrivacy.Nickname,
                    shynee.Profile.Nickname.Parameter),
                new ShyneeProfileParameter<string>(
                    fieldsPrivacy.AvatarUri,
                    shynee.Profile.AvatarUri.Parameter),
                new ShyneeProfileParameter<string>(
                    fieldsPrivacy.Name,
                    shynee.Profile.Name.Parameter),
                new ShyneeProfileParameter<DateTime>(
                    fieldsPrivacy.Dob,
                    shynee.Profile.Dob.Parameter),
                new ShyneeProfileParameter<Gender>(
                    fieldsPrivacy.Gender,
                    shynee.Profile.Gender.Parameter),
                new ShyneeProfileParameter<string[]>(
                    fieldsPrivacy.Interests,
                    shynee.Profile.Interests.Parameter),
                new ShyneeProfileParameter<string>(
                    fieldsPrivacy.PersonalInfo,
                    shynee.Profile.PersonalInfo.Parameter));
            shynee.UpdateProfile(shyneeProfileToUpdate);
            _shyneesRepository.UpdateShyneeAsync(shynee);
            return fieldsPrivacy;
        }

        public async Task<ShyneeProfileFieldsPrivacyDto> GetShyneeProfileFieldsPrivacyAsync(
            Guid id)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            var shyneeProfileFieldsPrivacyDto = shynee.Profile
                .GenerateProfileFieldsBoolValues();
            return shyneeProfileFieldsPrivacyDto;
        }

        public async Task UpdateShyneeCoordinatesAsync(
            Guid id, 
            ShyneeCoordinates coordinates)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(id);
            shynee.UpdateCoordinates(coordinates);
            await _shyneesRepository.UpdateShyneeAsync(shynee);
        }

        public async Task<UploadedAssetPathDto> UpdateShyneeAvatarAsync(
            Guid shyneeId,
            string assetPath)
        {
            var shynee = await _shyneesRepository.GetShyneeAsync(shyneeId);
            var updatedShyneeProfile = new ShyneeProfile(
                shynee.Profile.Nickname.Parameter,
                assetPath,
                shynee.Profile.Name.Parameter,
                shynee.Profile.Dob.Parameter,
                shynee.Profile.Gender.Parameter,
                shynee.Profile.Interests.Parameter,
                shynee.Profile.PersonalInfo.Parameter);
            shynee.UpdateProfile(updatedShyneeProfile);
            _shyneesRepository.UpdateShyneeAsync(shynee);
            var uploadedAssetUri = new UploadedAssetPathDto(
                shynee.Profile.AvatarUri.Parameter);
            return uploadedAssetUri;
        }
    }
}
