using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShyneeBackend.Infrastructure.Repositories.InMemoryRepositories
{
    public class InMemoryShyneesRepository : IShyneesRepository
    {
        private static readonly List<Shynee> _shyneesStore;

        private bool IsPasswordValid(string shyneeHash, string password)
        {
            return Hasher.VerifyPassword(shyneeHash, password);
        }

        static InMemoryShyneesRepository()
        {
            _shyneesStore = ShyneesDataFaker.GenerateShynees();
        }

        public async Task<Shynee> GetShynee(Guid id)
        {

            var shynee = _shyneesStore.Find(s => s.Id == id);
            return shynee == null ? throw new ShyneeNotFoundException() : shynee;
        }

        public async Task<Shynee> UpdateShynee(Shynee shynee)
        {
            var shyneeToUpdate = _shyneesStore.Find(s => shynee.Id == s.Id);
            _shyneesStore.Remove(shyneeToUpdate);
            _shyneesStore.Add(shynee);
            return shynee;
        }

        public async Task<IEnumerable<ShyneeCoordinates>> GetShyneeCoordinates()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shynee>> GetShynees()
        {
            return _shyneesStore;
        }

        public async Task<bool> IsShyneeExists(string email)
        {
            return _shyneesStore.Exists(s => s.Credentials.Email == email);
        }

        public async Task<Guid> CreateShynee(Shynee shynee)
        {
            _shyneesStore.Add(shynee);
            return shynee.Id;
        }

        public async Task<Shynee> FindShyneeByCredentials(ShyneeCredentials credentials)
        {
            if (!await IsShyneeExists(credentials.Email))
                throw new ShyneeNotFoundException();
            var shynee = _shyneesStore.Single(s => s.Credentials.Email == credentials.Email);
            var shyneeHash = shynee.Credentials.Password;
            if (!IsPasswordValid(shyneeHash, credentials.Password))
                throw new InvalidPasswordException();
            return shynee;
        }
    }
}
