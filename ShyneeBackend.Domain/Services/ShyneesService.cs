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

        public IEnumerable<ShyneesAroundListInfo> GetShyneesAroundList(
            ShyneeCoordinates shyneeCoordinates)
        {
            var shyneesAroundListInfos = _shyneesRepository.GetShynees()
                //.Where(s => CoordinatesManager.CalculateDistance(
                //    shyneeCoordinates.Latitude, 
                //    shyneeCoordinates.Longitude, 
                //    s.Coordinates.Latitude, 
                //    s.Coordinates.Longitude) <= _radiusAround)
                .Select(s => 
                    new ShyneesAroundListInfo(s.Id, 
                        s.Profile.Nickname.Status == ShyneeProfileParameterStatusType.Visible ?
                            s.Profile.Nickname.Parameter : _defaultShyneeNickname, 
                        s.Profile.AvatarUri.Status == ShyneeProfileParameterStatusType.Visible ?
                            s.Profile.AvatarUri.Parameter : null));
            return shyneesAroundListInfos;
        }
    }
}
