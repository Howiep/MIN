using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace M_Core.Migrations
{
    public partial class UpdatedShiftesAndGroupsWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Group_GroupID",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Shift_ShiftID",
                table: "Experiences");

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

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Group",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Group");

            migrationBuilder.AddColumn<int>(
                name: "GroupID",
                table: "Experiences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShiftID",
                table: "Experiences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_GroupID",
                table: "Experiences",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ShiftID",
                table: "Experiences",
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
    }
}
