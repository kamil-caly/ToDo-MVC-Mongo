using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using ToDoList.Infrastructure;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class ToDoRepository
    {
        private readonly MongoDbContext _dbContext;

        public ToDoRepository(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ToDoItem>> GetAllAsync() =>
            await _dbContext.toDoItems.ToListAsync();

        public async Task<ToDoItem?> GetByIdAsync(ObjectId id) =>
            await _dbContext.toDoItems.FirstOrDefaultAsync(todo => todo.Id == id);

        public async Task AddAsync(ToDoItem newItem)
        {
            await _dbContext.toDoItems.AddAsync(newItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ToDoItem updatedItem)
        {
            var itemToUpdate = await _dbContext.toDoItems.FirstOrDefaultAsync(t => t.Id == updatedItem.Id);

            if (itemToUpdate != null)
            {
                itemToUpdate.Title = updatedItem.Title;
                itemToUpdate.Description = updatedItem.Description;
                itemToUpdate.IsCompleted = updatedItem.IsCompleted;

                _dbContext.toDoItems.Update(itemToUpdate);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("The ToDoItem to update cannot be found.");
            }
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var itemToDelete = await _dbContext.toDoItems.FirstOrDefaultAsync(t => t.Id == id);
            if (itemToDelete != null)
            {
                _dbContext.toDoItems.Remove(itemToDelete);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("The ToDoItem to delete cannot be found.");
            }
        }
    }
}
