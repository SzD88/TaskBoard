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
                .Property(b => b.Id)
                .IsRequired();
             builder
                .Property(b => b.ProjectNumber)
                .IsRequired();
             builder
                .Property(b => b.Title)
                .HasMaxLength(200)
                .IsRequired();
             builder
                .Property(b => b.LastModified)
                .IsRequired();
             builder
                .Property(b => b.Completed)
                .IsRequired();
            
        }
    }
}
