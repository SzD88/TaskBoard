using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class SubTaskEntityTypeConfiguration : IEntityTypeConfiguration<SubTask>
    {
        public void Configure(EntityTypeBuilder<SubTask> builder)
        {
            builder
                .Property(b => b.Id)
                .IsRequired();
             builder
                .Property(b => b.LevelAboveId)
                .IsRequired();
             builder
                .Property(b => b.Content)
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
