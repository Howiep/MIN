using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M_Core.Migrations
{
    public partial class WorkAndGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Experiences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftID",
                table: "Experiences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.ShiftID);
                    table.ForeignKey(
                        name: "FK_Shift_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceGroups",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(nullable: false),
                    GroupID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceGroups", x => new { x.ExperienceID, x.GroupID });
                    table.ForeignKey(
                        name: "FK_ExperienceGroups_Experiences_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experiences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceGroups_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftExperiences",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(nullable: false),
                    ShiftID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftExperiences", x => new { x.ExperienceID, x.ShiftID });
                    table.ForeignKey(
                        name: "FK_ShiftExperiences_Experiences_ExperienceID",
                        column: x => x.ExperienceID,
                        principalTable: "Experiences",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftExperiences_Shift_ShiftID",
                        column: x => x.ShiftID,
                        principalTable: "Shift",
                        principalColumn: "ShiftID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_GroupID",
                table: "Experiences",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ShiftID",
                table: "Experiences",
                column: "ShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceGroups_GroupID",
                table: "ExperienceGroups",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_UserId",
                table: "Shift",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftExperiences_ShiftID",
                table: "ShiftExperiences",
                column: "ShiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Group_GroupID",
                table: "Experiences",
                column: "GroupID",
                principalTable: "Group",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Shift_ShiftID",
                table: "Experiences",
                column: "ShiftID",
                principalTable: "Shift",
                principalColumn: "ShiftID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Group_GroupID",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Shift_ShiftID",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "ExperienceGroups");

            migrationBuilder.DropTable(
                name: "ShiftExperiences");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_GroupID",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_ShiftID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "GroupID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "ShiftID",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "AspNetUsers");
        }
    }
}
