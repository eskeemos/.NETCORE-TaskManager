using Microsoft.EntityFrameworkCore;

namespace TaskManager.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
