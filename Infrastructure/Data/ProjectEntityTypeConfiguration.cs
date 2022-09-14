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

            builder
             .Property(pl => pl.Id)
             .HasConversion(id => id.GetValue(), id => new Id(id));
             
            builder.Property(typeof(ProjectNumber), "_projectNumber")
                .HasConversion(projectNumberConverter)
                .HasColumnName("ProjectNumber");

            builder.Property(typeof(Title), "_title")
                .HasConversion(titleConverter)
                .HasColumnName("Title")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(typeof(Description), "_description")
                .HasConversion(descriptionConverter)
                .HasColumnName("Description")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(typeof(Completed), "_completed")
                .HasConversion(completedConverter)
                .HasColumnName("Completed")
                .IsRequired();
             
             builder.HasMany(typeof(SubTask), "_items");  // was guid 
             

        }
    }
}
