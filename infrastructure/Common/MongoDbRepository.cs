using Contracts.Domains;
using Contracts.Domains.Interfaces.MongoDb;
using Infrastructure.Common.Repositories.MongoDb;
using MongoDB.Driver;
using Shared.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public class MongoDbRepository<T> : MongoDbRepositoryAsync<T>, IMongoDbRepositoryBase<T> where T : MongoEntity
    {
        public MongoDbRepository(IMongoClient client, DatabaseSettings settings)
        {
            Database = client.GetDatabase(settings.DatabaseName)
                .WithWriteConcern(WriteConcern.Acknowledged);
        }

        protected virtual IMongoCollection<T> Collection =>
            Database.GetCollection<T>(GetCollectionName());

        public IMongoCollection<T> FindAll(ReadPreference? readPreference = null)
        {
            return Database
                .WithReadPreference(readPreference ?? ReadPreference.Primary)
                .GetCollection<T>(GetCollectionName());
        }
    }
}
