using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations;

  public partial class New1 : Migration
  {
      protected override void Up(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.CreateTable(
              name: "Projects",
              columns: table => new
              {
                  Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  ProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                  Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                  Completed = table.Column<bool>(type: "bit", nullable: false),
                  Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                  LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Projects", x => x.Id);
              });

          migrationBuilder.CreateTable(
              name: "SubTasks",
              columns: table => new
              {
                  Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                  Completed = table.Column<bool>(type: "bit", nullable: false),
                  LevelAboveId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                  Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                  LastModified = table.Column<DateTime>(type: "datetime2", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_SubTasks", x => x.Id);
              });
      }

      protected override void Down(MigrationBuilder migrationBuilder)
      {
          migrationBuilder.DropTable(
              name: "Projects");

          migrationBuilder.DropTable(
              name: "SubTasks");
      }
  }
