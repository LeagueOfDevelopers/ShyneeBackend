using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IRepositories;

namespace ShyneeBackend.Infrastructure.Repositories.DatabaseRepositories
{
    public class ShyneesRepository : IShyneesRepository
    {
        public Task<Guid> CreateShyneeAsync(Shynee shynee)
        {
            throw new NotImplementedException();
        }

        public Task<Shynee> FindShyneeByCredentialsAsync(ShyneeCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public Task<Shynee> GetShyneeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShyneeCoordinates>> GetShyneeCoordinatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shynee>> GetShyneesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsShyneeExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Shynee> UpdateShyneeAsync(Shynee shynee)
        {
            throw new NotImplementedException();
        }
    }
}
