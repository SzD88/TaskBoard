﻿using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TaskBoardContext))]
    partial class TaskBoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Day", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("_completed")
                        .HasColumnType("bit")
                        .HasColumnName("Completed");

                    b.Property<DateTime?>("_dayDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DayDate");

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Description");

                    b.Property<string>("_title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.ToTable("Days", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.SubTask", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("_completed")
                        .HasColumnType("bit")
                        .HasColumnName("Completed");

                    b.Property<string>("_content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Content");

                    b.Property<DateTime?>("_dayDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DayDate");

                    b.Property<Guid>("_levelAboveId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LevelAboveId");

                    b.HasKey("Id");

                    b.ToTable("SubTasks", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
