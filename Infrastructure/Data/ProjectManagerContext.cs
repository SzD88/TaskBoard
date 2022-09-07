using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class ProjectManagerContext : DbContext
    {
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ProjectEntityTypeConfiguration().Configure(modelBuilder.Entity<Project>());
            new SubTaskEntityTypeConfiguration().Configure(modelBuilder.Entity<SubTask>());
        }
        public ProjectManagerContext(DbContextOptions options) : base(options)
        {

        }
      
    }
}
