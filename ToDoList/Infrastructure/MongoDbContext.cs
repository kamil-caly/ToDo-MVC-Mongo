using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ToDoList.Models;

namespace ToDoList.Infrastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<ToDoItem> ToDoItems => _database.GetCollection<ToDoItem>("ToDoItems");
    }
}
