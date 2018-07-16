using ShyneeBackend.Domain.Entities;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IRepositories
{
    public interface IShyneesRepository
    {
        IEnumerable<ShyneeProfile> GetShyneeProfiles();
    }
}
