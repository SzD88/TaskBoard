using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProjectManagerContext : DbContext
    {
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SubTaskEntityTypeConfiguration().Configure(modelBuilder.Entity<SubTask>());

            new ProjectEntityTypeConfiguration().Configure(modelBuilder.Entity<Project>());
           
        }
        public ProjectManagerContext(DbContextOptions options) : base(options)
        {

        }
      
    }
}
