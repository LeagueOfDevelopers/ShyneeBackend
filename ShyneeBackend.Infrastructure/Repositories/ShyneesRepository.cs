using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IRepositories;
using System.Collections.Generic;
using ShyneeBackend.Helpers;

namespace ShyneeBackend.Infrastructure.Repositories
{
    public class ShyneesRepository : IShyneesRepository
    {
        public IEnumerable<ShyneeProfile> GetShyneeProfiles()
        {
            return ShyneesDataFaker.GetShyneeProfiles();
        }
    }
}
