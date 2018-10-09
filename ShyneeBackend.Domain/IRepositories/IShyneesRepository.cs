using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShyneeBackend.Domain.IRepositories
{
    public interface IShyneesRepository
    {
        Task<IEnumerable<Shynee>> GetShyneesAsync();

        Task<IEnumerable<ShyneeCoordinates>> GetShyneeCoordinatesAsync();

        Task<Shynee> GetShyneeAsync(Guid id);

        Task<Shynee> UpdateShyneeAsync(Shynee shynee);

        Task<bool> IsShyneeExistsAsync(string email);

        Task<Guid> CreateShyneeAsync(Shynee shynee);

        Task<Shynee> FindShyneeByCredentialsAsync(
            ShyneeCredentials credentials);
    }
}
