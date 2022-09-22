using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data
{
    public class SubTaskEntityTypeConfiguration : IEntityTypeConfiguration<SubTask>
    {
        public void Configure(EntityTypeBuilder<SubTask> builder)
        { 
            var contentConverter = new ValueConverter<Content, string>(cnt => cnt.Value,
                 dbvalue => new Content(dbvalue));
            var completedConverter = new ValueConverter<Completed, bool>(desc => desc.Value,
                dbvalue => new Completed(dbvalue));
            var idConverter = new ValueConverter<Id, Guid>(id => id.Value,
                dbvalue => new Id(dbvalue));

            builder
              .ToTable("SubTasks");
            builder
             .HasKey(b => b.Id);

            builder
             .Property(pl => pl.Id)
             .HasConversion(id => id.Value, id => new Id(id));

            builder.Property(typeof(Content), "_content")
                .HasConversion(contentConverter)
                .HasColumnName("Content")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(typeof(Completed), "_completed")
                .HasConversion(completedConverter)
                .HasColumnName("Completed")
                .IsRequired();

            builder.Property(typeof(Id), "_levelAboveId")
               .HasConversion(idConverter)
               .HasColumnName("LevelAboveId")
               .IsRequired(); 

        }
    }
}
