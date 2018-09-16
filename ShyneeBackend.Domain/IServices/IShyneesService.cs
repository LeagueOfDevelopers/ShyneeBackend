using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IServices
{
    public interface IShyneesService
    {
        IEnumerable<ShyneeAroundDto> GetShyneesAroundList(ShyneeCoordinates shyneeCoordinates);

        Shynee CreateShynee(
            ShyneeCredentials shyneeCredentials,
            ShyneeProfile shyneeProfile);

        Shynee GetShynee(
            Guid id);

        ShyneeProfileDto GetShyneePublicData(
            Guid id);

        void UpdateShyneeCoordinates(
            Guid id,
            ShyneeCoordinates coordinates);

        ShyneeProfileDto GetShyneeProfile(
            Guid id);

        ShyneeProfileDto UpdateShyneeProfile(
            Guid id,
            ShyneeProfile profile);

        ShyneeProfileFieldsPrivacyDto GetShyneeProfileFieldsPrivacy(
            Guid id);

        ShyneeProfileFieldsPrivacyDto UpdateShyneeProfileFieldsPrivacy(
            Guid id,
            ShyneeProfileFieldsPrivacyDto fieldsPrivacy);

        ShyneeSettingsDto GetShyneeSettings(
            Guid id);

        ShyneeSettingsDto UpdateShyneeSettings(
            Guid id, 
            ShyneeSettings ShyneeSettings);

        ShyneeIsReadySettingDto ChangeShyneeReadySetting(
            Guid id, 
            bool isReady);

        Shynee FindShyneeByCredentials(
            ShyneeCredentials credentials);
    }
}
