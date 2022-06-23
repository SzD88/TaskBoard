using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ProjectManagerContext : DbContext
    {
        public ProjectManagerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SubTask> SubTasks { get; set; }
         public DbSet<Project> Projects { get; set; }
      //  public DbSet<SubTask> SubTasks { get; set; }
    }
}
