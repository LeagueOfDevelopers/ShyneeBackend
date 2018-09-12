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
            Entities.ShyneeProfile shyneeProfile);

        Shynee GetShynee(Guid id);

        ShyneeProfilePublicData GetShyneePublicData(Guid id);

        DTOs.ShyneeProfile GetShyneeProfile(Guid id);

        DTOs.ShyneeProfile UpdateShyneeProfile(
            Guid id,
            Entities.ShyneeProfile profile);

        ShyneeReadySettings GetShyneeReadySettings(Guid id);

        bool ChangeShyneeReadySetting(Guid id, bool isReady);
    }
}
