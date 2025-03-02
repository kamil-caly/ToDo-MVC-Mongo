using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using ToDoList.Models;

namespace ToDoList.Infrastructure
{
    public class MongoDbContext : DbContext
    {
        public DbSet<ToDoItem> toDoItems { get; set; }

        public MongoDbContext(DbContextOptions options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoItem>();
        }
    }
}
