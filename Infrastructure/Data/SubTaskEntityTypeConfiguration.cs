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
            //private readonly LinkedList<Guid> _includedSubTasks = new();
            var contentConverter = new ValueConverter<Content, string>(cnt => cnt.GetValue(),
                 dbvalue => new Content(dbvalue));
            var completedConverter = new ValueConverter<Completed, bool>(desc => desc.GetValue(),
                dbvalue => new Completed(dbvalue));
            var idConverter = new ValueConverter<Id, Guid>(id => id.GetValue(),
                dbvalue => new Id(dbvalue));

            builder
              .ToTable("SubTasks");
            builder
             .HasKey(b => b.Id);

            builder
             .Property(pl => pl.Id)
             .HasConversion(id => id.GetValue(), id => new Id(id));

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

             builder.HasMany(typeof(SubTask), "_includedSubTasks"); // tu jest blad 

        }
    }
}
