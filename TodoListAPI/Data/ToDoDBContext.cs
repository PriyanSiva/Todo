using Microsoft.EntityFrameworkCore;
using TodoListModels;


namespace TodoListAPI.Data
{
    public class ToDoDbContext : DbContext
    {
        // create a db context for the database using ToDoListClassLibrary
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoDbContext() { }

        // referecen for database migration
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) => Database.Migrate();

        //database configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite();
    }

}
