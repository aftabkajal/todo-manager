

using System.Data.Entity;
using TodoManager.Core.Entities;

namespace TodoManager.Infrastructure.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext() : base("DefaultConnection")
        {

        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}