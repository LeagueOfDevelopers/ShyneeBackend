using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShyneeBackend.Domain.IServices
{
    public interface IShyneesService
    {
        Task<IEnumerable<ShyneeAroundDto>> GetShyneesAroundListAsync(
            ShyneeCoordinates shyneeCoordinates);

        Task<Shynee> CreateShyneeAsync(
            ShyneeCredentials shyneeCredentials,
            ShyneeProfile shyneeProfile);

        Task<Shynee> GetShyneeAsync(
            Guid id);

        Task<ShyneeProfileDto> GetShyneePublicDataAsync(
            Guid id);

        Task UpdateShyneeCoordinatesAsync(
            Guid id,
            ShyneeCoordinates coordinates);

        Task<ShyneeProfileDto> GetShyneeProfile(
            Guid id);

        Task<ShyneeProfileDto> UpdateShyneeProfileAsync(
            Guid id,
            ShyneeProfile profile);

        Task<ShyneeProfileFieldsPrivacyDto> GetShyneeProfileFieldsPrivacyAsync(
            Guid id);

        Task<ShyneeProfileFieldsPrivacyDto> UpdateShyneeProfileFieldsPrivacyAsync(
            Guid id,
            ShyneeProfileFieldsPrivacyDto fieldsPrivacy);

        Task<ShyneeSettingsDto> GetShyneeSettingsAsync(
            Guid id);

        Task<ShyneeSettingsDto> UpdateShyneeSettingsAsync(
            Guid id, 
            ShyneeSettings ShyneeSettings);

        Task<ShyneeIsReadySettingDto> ChangeShyneeReadySettingAsync(
            Guid id, 
            bool isReady);

        Task<Shynee> FindShyneeByCredentialsAsync(
            ShyneeCredentials credentials);

        Task<UploadedAssetPathDto> UpdateShyneeAvatarAsync(
            Guid shyneeId,
            string assetPath);
    }
}
