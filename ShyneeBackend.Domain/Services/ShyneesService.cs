using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShyneeBackend.Domain.Services
{
    public class ShyneesService : IShyneesService
    {
        private readonly IShyneesRepository _shyneesRepository;
        private readonly string _defaultShyneeNickname;
        private readonly double _radiusAround;

        public ShyneesService(
            IShyneesRepository shyneesRepository,
            string defaultShyneeNickname,
            double radiusAround)
        {
            _shyneesRepository = shyneesRepository;
            _defaultShyneeNickname = defaultShyneeNickname;
            _radiusAround = radiusAround;
        }

        public Shynee GetShynee(Guid id)
        {
            return _shyneesRepository.GetShynee(id);
        }

        public ShyneeProfileForEdit GetShyneeProfileForEdit(Guid id)
        {
            throw new NotImplementedException();
        }

        public ShyneeProfilePublicData GetShyneePublicData(Guid id)
        {
            var shyneeProfile = _shyneesRepository.GetShynee(id).Profile;
            var shyneeProfilePublicData = shyneeProfile.GeneratePublicShyneeProfile();
            return shyneeProfilePublicData;
        }

        public ShyneeReadySettings GetShyneeReadySettings(Guid id)
        {
            var shyneeReadySettings = _shyneesRepository.GetShynee(id).ReadySettings;
            return shyneeReadySettings;
        }

        public bool ChangeShyneeReadySetting(Guid id, bool isReady)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            shynee.ReadySettings.IsReady = isReady;
            var updatedShynee = _shyneesRepository.UpdateShynee(shynee);
            return updatedShynee.ReadySettings.IsReady;
        }

        public IEnumerable<ShyneesAroundList> GetShyneesAroundList(
            ShyneeCoordinates shyneeCoordinates)
        {
            var shyneesAroundListInfos = _shyneesRepository.GetShynees()
                //.Where(s => s.Coordinates.CalculateDistance(
                //    shyneeCoordinates.Latitude,
                //    shyneeCoordinates.Longitude) <= _radiusAround)
                .Select(s =>
                {
                    var publicProfile = s.Profile.GeneratePublicShyneeProfile();
                    return new ShyneesAroundList(s.Id,
                        publicProfile.Nickname,
                        publicProfile.AvatarUri);
                });
            return shyneesAroundListInfos;
        }
    }
}
