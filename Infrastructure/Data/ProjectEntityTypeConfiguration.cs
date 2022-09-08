using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
                .ToTable("Projects");

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.ProjectNumber);

            builder
                 .Property(b => b.Title)
                 .HasMaxLength(100)
                 .IsRequired(); 

            builder
               .Property(b => b.Description)
               .HasMaxLength(100)
               .IsRequired();

            builder
               .Property(b => b.Completed)
               .IsRequired();
            builder
              .Property(b => b.Working);
             
            builder
                .Ignore(b => b.MainTasks); 
        }
    }
}
