using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M_Core.Migrations
{
    public partial class ChangedShift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shift_AspNetUsers_UserId",
                table: "Shift");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftExperiences_Experiences_ExperienceID",
                table: "ShiftExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftExperiences_Shift_ShiftID",
                table: "ShiftExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShiftExperiences",
                table: "ShiftExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shift",
                table: "Shift");

            migrationBuilder.RenameTable(
                name: "ShiftExperiences",
                newName: "ShiftExperiences");

            migrationBuilder.RenameTable(
                name: "Shift",
                newName: "Shift");

            migrationBuilder.RenameColumn(
                name: "ShiftID",
                table: "ShiftExperiences",
                newName: "ShiftID");

            migrationBuilder.RenameIndex(
                name: "IX_ShiftExperiences_ShiftID",
                table: "ShiftExperiences",
                newName: "IX_ShiftExperiences_ShiftID");

            migrationBuilder.RenameColumn(
                name: "ShiftID",
                table: "Shift",
                newName: "ShiftID");

            migrationBuilder.RenameIndex(
                name: "IX_Shift_UserId",
                table: "Shift",
                newName: "IX_Shift_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShiftExperiences",
                table: "ShiftExperiences",
                columns: new[] { "ExperienceID", "ShiftID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shift",
                table: "Shift",
                column: "ShiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shift_AspNetUsers_UserId",
                table: "Shift",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftExperiences_Experiences_ExperienceID",
                table: "ShiftExperiences",
                column: "ExperienceID",
                principalTable: "Experiences",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftExperiences_Shift_ShiftID",
                table: "ShiftExperiences",
                column: "ShiftID",
                principalTable: "Shift",
                principalColumn: "ShiftID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shift_AspNetUsers_UserId",
                table: "Shift");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftExperiences_Experiences_ExperienceID",
                table: "ShiftExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_ShiftExperiences_Shift_ShiftID",
                table: "ShiftExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShiftExperiences",
                table: "ShiftExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shift",
                table: "Shift");

            migrationBuilder.RenameTable(
                name: "ShiftExperiences",
                newName: "ShiftExperiences");

            migrationBuilder.RenameTable(
                name: "Shift",
                newName: "Shift");

            migrationBuilder.RenameColumn(
                name: "ShiftID",
                table: "ShiftExperiences",
                newName: "ShiftID");

            migrationBuilder.RenameIndex(
                name: "IX_ShiftExperiences_ShiftID",
                table: "ShiftExperiences",
                newName: "IX_ShiftExperiences_ShiftID");

            migrationBuilder.RenameColumn(
                name: "ShiftID",
                table: "Shift",
                newName: "ShiftID");

            migrationBuilder.RenameIndex(
                name: "IX_Shift_UserId",
                table: "Shift",
                newName: "IX_Shift_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShiftExperiences",
                table: "ShiftExperiences",
                columns: new[] { "ExperienceID", "ShiftID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shift",
                table: "Shift",
                column: "ShiftID");

            migrationBuilder.AddForeignKey(
                name: "FK_Shift_AspNetUsers_UserId",
                table: "Shift",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftExperiences_Experiences_ExperienceID",
                table: "ShiftExperiences",
                column: "ExperienceID",
                principalTable: "Experiences",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShiftExperiences_Shift_ShiftID",
                table: "ShiftExperiences",
                column: "ShiftID",
                principalTable: "Shift",
                principalColumn: "ShiftID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
