using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;

namespace ToDoList.Models
{
    [Collection("ToDoItem")]
    public class ToDoItem
    {
        public ObjectId Id { get; set; }
      
        public string Title { get; set; } = string.Empty;
        
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
