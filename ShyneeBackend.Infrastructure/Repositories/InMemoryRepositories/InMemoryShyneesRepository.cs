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
        private static readonly List<Shynee> shyneesStore;

        static InMemoryShyneesRepository()
        {
            shyneesStore = ShyneesDataFaker.GenerateShynees();
        }

        public Shynee GetShynee(Guid id)
        {
            var shynee = shyneesStore.Single(s => s.Id == id);
            return shynee == null ? throw new ShyneeNotFoundException() : shynee;
        }

        public IEnumerable<ShyneeCoordinates> GetShyneeCoordinates()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shynee> GetShynees()
        {
            return shyneesStore;
        }
    }
}
