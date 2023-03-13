using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caretaker_EFC.Migrations
{
    /// <inheritdoc />
    public partial class idtoerrandsinaddressentityremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Errands_AddressId",
                table: "Errands");

            migrationBuilder.DropColumn(
                name: "ErrandId",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Errands_AddressId",
                table: "Errands",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Errands_AddressId",
                table: "Errands");

            migrationBuilder.AddColumn<int>(
                name: "ErrandId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Errands_AddressId",
                table: "Errands",
                column: "AddressId",
                unique: true);
        }
    }
}
