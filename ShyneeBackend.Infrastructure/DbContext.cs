using MongoDB.Driver;
using ShyneeBackend.Domain.Entities;
using ShyneeBackend.Infrastructure.Exceptions;

namespace ShyneeBackend.Infrastructure
{
    public class DbContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly DbSettings _dbSettings;

        public DbContext(DbSettings dbSettings)
        {
            _dbSettings = dbSettings;
            var client = new MongoClient(_dbSettings.ConnectionString);
            if (client == null)
                throw new DatabaseNotFound();
            _database = client.GetDatabase(_dbSettings.Database);
        }

        public IMongoCollection<Shynee> Shynees
        {
            get
            {
                return _database.GetCollection<Shynee>("Shynee");
            }
        }
    }
}
