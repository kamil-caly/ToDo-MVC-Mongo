using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ToDoList.Models
{
    public class ToDoItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;

        [BsonElement("description")]
        public string Description { get; set; } = string.Empty;

        [BsonElement("isCompleted")]
        public bool IsCompleted { get; set; } = false;
    }
}
