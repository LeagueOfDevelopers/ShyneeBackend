using ShyneeBackend.Domain.DTOs;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Domain.IServices;
using System.Collections.Generic;
using System.Linq;

namespace ShyneeBackend.Domain.Services
{
    public class ShyneesService : IShyneesService
    {
        private readonly IShyneesRepository _shyneesRepository;

        public ShyneesService(IShyneesRepository shyneesRepository)
        {
            _shyneesRepository = shyneesRepository;
        }

        public IEnumerable<ShyneesAroundListInfo> GetShyneesAroundList()
        {
            var shyneesAroundListInfos = _shyneesRepository.GetShyneeProfiles()
                .Select(s => new ShyneesAroundListInfo(s.Id, 
                    s.Nickname.Key ? "Незнакомец" : s.Nickname.Value));
            return shyneesAroundListInfos;
        }
    }
}
