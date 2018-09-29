using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IRepositories;

namespace ShyneeBackend.Infrastructure.Repositories.DatabaseRepositories
{
    public class ShyneesRepository : IShyneesRepository
    {
        public Task<Guid> CreateShynee(Shynee shynee)
        {
            throw new NotImplementedException();
        }

        public Task<Shynee> FindShyneeByCredentials(ShyneeCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public Task<Shynee> GetShynee(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShyneeCoordinates>> GetShyneeCoordinates()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shynee>> GetShynees()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsShyneeExists(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Shynee> UpdateShynee(Shynee shynee)
        {
            throw new NotImplementedException();
        }
    }
}
