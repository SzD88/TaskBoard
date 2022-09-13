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
