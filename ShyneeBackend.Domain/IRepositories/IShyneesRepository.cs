using ShyneeBackend.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ShyneeBackend.Domain.IRepositories
{
    public interface IShyneesRepository
    {
        IEnumerable<Shynee> GetShynees();

        IEnumerable<ShyneeCoordinates> GetShyneeCoordinates();

        Shynee GetShynee(Guid id);

        Shynee UpdateShynee(Shynee shynee);

        bool IsShyneeExists(string email);

        Guid CreateShynee(Shynee shynee);
    }
}
