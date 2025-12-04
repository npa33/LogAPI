using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domains.Interfaces.MongoDb
{
    public interface IMongoDbRepositoryBase<T> : IMongoDbRepositoryAsync<T> where T : MongoEntity    
    {
        IMongoCollection<T> FindAll(ReadPreference? readPreference = null);
    }
}
