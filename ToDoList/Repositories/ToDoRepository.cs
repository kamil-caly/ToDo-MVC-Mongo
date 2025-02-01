using MongoDB.Driver;
using ToDoList.Infrastructure;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class ToDoRepository
    {
        private readonly IMongoCollection<ToDoItem> _toDos;

        public ToDoRepository(MongoDbContext dbContext)
        {
            _toDos = dbContext.ToDoItems;
        }

        public async Task<List<ToDoItem>> GetAllAsync() =>
            await _toDos.Find(_ => true).ToListAsync();

        public async Task<ToDoItem?> GetByIdAsync(string id) =>
            await _toDos.Find(todo => todo.Id == id).FirstOrDefaultAsync();

        public async Task AddAsync(ToDoItem newItem) =>
            await _toDos.InsertOneAsync(newItem);

        public async Task UpdateAsync(string id, ToDoItem updatedItem) =>
            await _toDos.ReplaceOneAsync(todo => todo.Id == id, updatedItem);

        public async Task DeleteAsync(string id) =>
            await _toDos.DeleteOneAsync(todo => todo.Id == id);
    }
}
