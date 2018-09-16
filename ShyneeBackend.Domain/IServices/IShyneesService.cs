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

        ShyneeProfileDto GetShyneeProfile(
            Guid id);

        ShyneeProfileDto UpdateShyneeProfile(
            Guid id,
            ShyneeProfile profile);

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
