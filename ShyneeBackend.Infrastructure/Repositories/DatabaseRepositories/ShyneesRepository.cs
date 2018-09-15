using System;
using System.Collections.Generic;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.IRepositories;

namespace ShyneeBackend.Infrastructure.Repositories.DatabaseRepositories
{
    public class ShyneesRepository : IShyneesRepository
    {
        public Guid CreateShynee(Shynee shynee)
        {
            throw new NotImplementedException();
        }

        public Shynee FindShyneeByCredentials(ShyneeCredentials credentials)
        {
            throw new NotImplementedException();
        }

        public Shynee GetShynee(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShyneeCoordinates> GetShyneeCoordinates()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shynee> GetShynees()
        {
            throw new NotImplementedException();
        }

        public bool IsShyneeExists(string email)
        {
            throw new NotImplementedException();
        }

        public Shynee UpdateShynee(Shynee shynee)
        {
            throw new NotImplementedException();
        }
    }
}
