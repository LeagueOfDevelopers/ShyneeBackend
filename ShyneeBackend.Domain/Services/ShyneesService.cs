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

        public ShyneeProfileInfo GetShyneeProfile(Guid id)
        {
            var shyneeProfile = _shyneesRepository.GetShynee(id).Profile;
            var shyneeProfileForEdit = new ShyneeProfileInfo(
                id,
                shyneeProfile.Nickname,
                shyneeProfile.AvatarUri,
                shyneeProfile.Name,
                shyneeProfile.Dob,
                shyneeProfile.Gender,
                shyneeProfile.Interests,
                shyneeProfile.PersonalInfo);
            return shyneeProfileForEdit;
        }

        public ShyneeProfileInfo UpdateShyneeProfile(
            Guid id,
            ShyneeProfile profile)
        {
            var shynee = _shyneesRepository.GetShynee(id);
            shynee.UpdateProfile(profile);
            _shyneesRepository.UpdateShynee(shynee);
            return new ShyneeProfileInfo(
                id,
                profile.Nickname,
                profile.AvatarUri,
                profile.Name,
                profile.Dob,
                profile.Gender,
                profile.Interests,
                profile.PersonalInfo);
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
                .Where(s => s.Coordinates.CalculateDistance(
                    shyneeCoordinates.Latitude,
                    shyneeCoordinates.Longitude) <= _applicationSettings.RadiusAround)
                .Select(s =>
                {
                    var publicProfile = s.Profile.GeneratePublicShyneeProfile();
                    return new ShyneesAroundList(s.Id,
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
                new ShyneeReadySettings());
            var id = _shyneesRepository.CreateShynee(shynee);
            var createdShynee = _shyneesRepository.GetShynee(id);
            return createdShynee;
        }
    }
}
