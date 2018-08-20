using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IServices
{
    public interface IShyneesService
    {
        IEnumerable<ShyneesAroundList> GetShyneesAroundList(ShyneeCoordinates shyneeCoordinates);

        Shynee GetShynee(Guid id);

        ShyneeProfilePublicData GetShyneePublicData(Guid id);

        ShyneeProfileForEdit GetShyneeProfileForEdit(Guid id);

        ShyneeProfileForEdit UpdateShyneeProfile(
            Guid id,
            ShyneeProfile profileForEdit);

        ShyneeReadySettings GetShyneeReadySettings(Guid id);

        bool ChangeShyneeReadySetting(Guid id, bool isReady);
    }
}
