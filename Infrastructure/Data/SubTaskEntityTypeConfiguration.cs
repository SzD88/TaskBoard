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
                 .ToTable("SubTasks");

            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Content);

            builder
                 .Property(b => b.Completed)
                 .IsRequired();

            builder
               .Property(b => b.LevelAboveId);

            builder
                .Ignore(b => b.IncludedTasks);
        }
    }
}
