using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IServices
{
    public interface IShyneesService
    {
        IEnumerable<ShyneesAroundList> GetShyneesAroundList(ShyneeCoordinates shyneeCoordinates);

        ShyneeProfileWithCredentials CreateShynee(
            ShyneeCredentials shyneeCredentials, 
            Entities.ShyneeProfile shyneeProfile);

        ShyneeProfilePublicData GetShyneePublicData(Guid id);

        DTOs.ShyneeProfile GetShyneeProfile(Guid id);

        DTOs.ShyneeProfile UpdateShyneeProfile(
            Guid id,
            Entities.ShyneeProfile profile);

        ShyneeReadySettings GetShyneeReadySettings(Guid id);

        bool ChangeShyneeReadySetting(Guid id, bool isReady);
    }
}
