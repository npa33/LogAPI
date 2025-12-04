using MongoDB.Driver;
using SaveLog.Api.Entities;
using Shared.Configurations;

namespace SaveLog.Api.Persistence
{
    public class RectifierLogDbSeed
    {
        public async Task SeedDataAsync(IMongoClient mongoClient, MongoDbSettings settings)
        {
            var databaseName = settings.DatabaseName;
            var database = mongoClient.GetDatabase(databaseName);
            var inventoryCollection = database.GetCollection<RectifierLogEntry>("InventoryEntries");
            //if (await inventoryCollection.EstimatedDocumentCountAsync() == 0)
            //    await inventoryCollection.InsertManyAsync(GetPreconfiguredInventories());
        }
    }
}
