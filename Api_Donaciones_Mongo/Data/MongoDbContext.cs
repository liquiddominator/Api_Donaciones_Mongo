using Api_Donaciones_Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api_Donaciones_Mongo.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Comentario> Comentarios =>
            _database.GetCollection<Comentario>("Comentarios");
    }
}
