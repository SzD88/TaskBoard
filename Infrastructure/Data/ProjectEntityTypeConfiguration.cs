using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data
{
    public class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            //sets both side conversion
            var projectNumberConverter = new ValueConverter<ProjectNumber, string>(pnr => pnr.GetValue(),
                dbvalue => new ProjectNumber(dbvalue));
            var titleConverter = new ValueConverter<Title, string>(title => title.GetValue(),
                dbvalue => new Title(dbvalue));
            var descriptionConverter = new ValueConverter<Description, string>(desc => desc.GetValue(),
                dbvalue => new Description(dbvalue));
            var completedConverter = new ValueConverter<Completed, bool>(desc => desc.GetValue(),
                dbvalue => new Completed(dbvalue));
            builder
                .ToTable("Projects"); 
            builder
                .HasKey(b => b.Id); 

            builder.Property(typeof(ProjectNumber), "_projectNumber")
                .HasConversion(projectNumberConverter)
                .HasColumnName("ProjectNumber");

            builder.Property(typeof(Title), "_title")
                .HasConversion(titleConverter)
                .HasColumnName("Title");

            builder.Property(typeof(Description), "_description")
                .HasConversion(descriptionConverter)
                .HasColumnName("Description");

            builder.Property(typeof(Completed), "_completed")
                .HasConversion(completedConverter)
                .HasColumnName("Completed");

            builder.HasMany(typeof(Guid), "_items");
            //private readonly IReadOnlyList<SubTask> _mainTasksAsSubTasks; // = new();
            builder
                .Property(b => b.GetProjectNumber());

            builder
                 .Property(b => b.GetTitle())
                 .HasMaxLength(100)
                 .IsRequired(); 

            builder
               .Property(b => b.GetDescription())
               .HasMaxLength(100)
               .IsRequired();

            builder
               .Property(b => b.GetCompleted())
               .IsRequired();
             
        }
    }
}
