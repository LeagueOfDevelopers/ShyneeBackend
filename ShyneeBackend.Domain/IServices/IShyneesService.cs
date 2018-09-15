using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IServices
{
    public interface IShyneesService
    {
        IEnumerable<ShyneesAroundList> GetShyneesAroundList(ShyneeCoordinates shyneeCoordinates);

        Shynee CreateShynee(
            ShyneeCredentials shyneeCredentials,
            ShyneeProfile shyneeProfile);

        Shynee GetShynee(Guid id);

        ShyneeProfilePublicData GetShyneePublicData(Guid id);

        ShyneeProfileInfo GetShyneeProfile(Guid id);

        ShyneeProfileInfo UpdateShyneeProfile(
            Guid id,
            ShyneeProfile profile);

        ShyneeReadySettings GetShyneeReadySettings(Guid id);

        ShyneeSettings UpdateShyneeSettings(Guid id, ShyneeReadySettings shyneeReadySettings);

        bool ChangeShyneeReadySetting(Guid id, bool isReady);

        Shynee FindShyneeByCredentials(ShyneeCredentials credentials);
    }
}
