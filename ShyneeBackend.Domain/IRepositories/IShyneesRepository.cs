using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShyneeBackend.Domain.IRepositories
{
    public interface IShyneesRepository
    {
        Task<IEnumerable<Shynee>> GetShynees();

        Task<IEnumerable<ShyneeCoordinates>> GetShyneeCoordinates();

        Task<Shynee> GetShynee(Guid id);

        Task<Shynee> UpdateShynee(Shynee shynee);

        Task<bool> IsShyneeExists(string email);

        Task<Guid> CreateShynee(Shynee shynee);

        Task<Shynee> FindShyneeByCredentials(ShyneeCredentials credentials);
    }
}
