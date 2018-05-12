using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M_Core.Migrations
{
    public partial class Add_Unique_nameandsemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Experiences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExperienceCategories",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_Name",
                table: "Experiences",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceCategories_Name",
                table: "ExperienceCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceCategories_Semester",
                table: "ExperienceCategories",
                column: "Semester",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Experiences_Name",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_ExperienceCategories_Name",
                table: "ExperienceCategories");

            migrationBuilder.DropIndex(
                name: "IX_ExperienceCategories_Semester",
                table: "ExperienceCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Experiences",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExperienceCategories",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
