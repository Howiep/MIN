using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M_Core.Migrations
{
    public partial class AddedExpriences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExperienceCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceCategoryExperience",
                columns: table => new
                {
                    ExperienceCategoryID = table.Column<int>(nullable: false),
                    ExperienceID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceCategoryExperience", x => new { x.ExperienceCategoryID, x.ExperienceID });
                    table.ForeignKey(
                        name: "FK_ExperienceCategoryExperience_ExperienceCategories_ExperienceCategoryID",
                        column: x => x.ExperienceCategoryID,
                        principalTable: "ExperienceCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceCategoryExperience_Experiences_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experiences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceCategoryExperience_ExperienceID",
                table: "ExperienceCategoryExperience",
                column: "ExperienceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceCategoryExperience");

            migrationBuilder.DropTable(
                name: "ExperienceCategories");

            migrationBuilder.DropTable(
                name: "Experiences");
        }
    }
}
