using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TaskBoardContext : DbContext
    {
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Day> Days { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SubTaskEntityTypeConfiguration().Configure(modelBuilder.Entity<SubTask>());

            new DayEntityTypeConfiguration().Configure(modelBuilder.Entity<Day>());
           
        }
        public TaskBoardContext(DbContextOptions options) : base(options)
        {

        }
    }
}
