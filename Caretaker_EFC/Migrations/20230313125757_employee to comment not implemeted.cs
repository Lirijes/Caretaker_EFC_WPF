using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caretaker_EFC.Migrations
{
    /// <inheritdoc />
    public partial class employeetocommentnotimplemeted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Employees_EmployeeId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_EmployeeId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "EmployeeIdTwo",
                table: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "EmployeeIdTwo",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EmployeeId",
                table: "Comments",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Employees_EmployeeId",
                table: "Comments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
