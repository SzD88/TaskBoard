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
                .Property(b => b.GetContent());

            builder
                 .Property(b => b.GetCompleted())
                 .IsRequired();

            builder
               .Property(b => b.GetLevelAboveId());

            //builder
            //    .Ignore(b => b.IncludedTasks);
        }
    }
}
