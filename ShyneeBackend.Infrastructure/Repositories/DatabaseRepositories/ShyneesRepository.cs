using MongoDB.Driver;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Domain.Exceptions;
using ShyneeBackend.Domain.IRepositories;
using ShyneeBackend.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShyneeBackend.Infrastructure.Repositories.DatabaseRepositories
{
    public class ShyneesRepository : IShyneesRepository
    {
        private readonly DbContext _dbContext;

        private bool IsPasswordValid(string shyneeHash, string password)
        {
            return Hasher.VerifyPassword(shyneeHash, password);
        }

        public ShyneesRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreateShyneeAsync(Shynee shynee)
        {
            await _dbContext.Shynees.InsertOneAsync(shynee);
            return shynee.Id;
        }

        public async Task<Shynee> FindShyneeByCredentialsAsync(ShyneeCredentials credentials)
        {
            var builder = Builders<Shynee>.Filter;
            var filter = builder.Eq("Credentials.Email", credentials.Email);
            var shynee = await _dbContext.Shynees.Find(filter).FirstOrDefaultAsync();
            if (shynee != null)
                if (!IsPasswordValid(shynee.Credentials.Password, credentials.Password))
                    throw new InvalidPasswordException();
            return shynee;
        }

        public async Task<Shynee> GetShyneeAsync(Guid id)
        {
            var shynee = await _dbContext.Shynees.FindAsync(s => s.Id == id);
            return shynee.FirstOrDefault();
        }

        public Task<IEnumerable<ShyneeCoordinates>> GetShyneeCoordinatesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shynee>> GetShyneesAsync()
        {
            var shynees = await _dbContext.Shynees.Find(shynee  => true).ToListAsync();
            return shynees;
        }

        public async Task<bool> IsShyneeExistsAsync(string email)
        {
            var shynee = await _dbContext.Shynees.FindAsync(s => s.Credentials.Email == email);
            return shynee.FirstOrDefault() == null ? false : true;
        }

        public async Task<Shynee> UpdateShyneeAsync(Shynee shynee)
        {
            await _dbContext.Shynees.FindOneAndReplaceAsync(
                s => s.Id == shynee.Id, shynee);
            return shynee;
        }
    }
}
