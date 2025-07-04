using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace librarian.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCredentialNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserCredentials_ReaderId",
                table: "UserCredentials");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_ReaderId",
                table: "UserCredentials",
                column: "ReaderId",
                unique: true,
                filter: "[ReaderId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserCredentials_ReaderId",
                table: "UserCredentials");

            migrationBuilder.CreateIndex(
                name: "IX_UserCredentials_ReaderId",
                table: "UserCredentials",
                column: "ReaderId");
        }
    }
}
