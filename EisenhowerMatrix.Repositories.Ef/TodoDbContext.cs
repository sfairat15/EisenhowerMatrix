using EisenhowerMatrix.Entities;
using EisenhowerMatrix.Repositories.Ef.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EisenhowerMatrix.Repositories.Ef
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions options) : base(options)
        {
            ;
        }

        public DbSet<TodoTask> TodoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoTaskConfiguration());
        }
    }
}
