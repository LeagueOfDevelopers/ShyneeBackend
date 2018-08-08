using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShyneeBackend.Infrastructure.Repositories.InMemoryRepositories
{
    public class InMemoryShyneesRepository : IShyneesRepository
    {
        private static readonly List<Shynee> _shyneesStore;

        static InMemoryShyneesRepository()
        {
            _shyneesStore = ShyneesDataFaker.GenerateShynees();
        }

        public Shynee GetShynee(Guid id)
        {
            var shynee = _shyneesStore.Single(s => s.Id == id);
            return shynee == null ? throw new ShyneeNotFoundException() : shynee;
        }

        public Shynee UpdateShynee(Shynee shynee)
        {
            var shyneeToUpdate = _shyneesStore.Find(s => shynee.Id == s.Id);
            _shyneesStore.Remove(shyneeToUpdate);
            _shyneesStore.Add(shynee);
            return shynee;
        }

        public IEnumerable<ShyneeCoordinates> GetShyneeCoordinates()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shynee> GetShynees()
        {
            return _shyneesStore;
        }
    }
}
