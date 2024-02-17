using Microsoft.EntityFrameworkCore;
using ToDoListClassLibrary;

namespace ToDoListWebAPI.Data
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoDbContext() { }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) => Database.Migrate();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite();
    }

}
