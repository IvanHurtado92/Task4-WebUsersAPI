using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4_WebUsersAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUsers",
                table: "Users",
                newName: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Users",
                newName: "IdUsers");
        }
    }
}
