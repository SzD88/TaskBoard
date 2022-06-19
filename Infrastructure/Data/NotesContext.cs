using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class NotesContext : DbContext
    {
        public NotesContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Note> Notes { get; set; }
         }
}
