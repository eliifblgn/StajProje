using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecKaliteDb.Migrations
{
    /// <inheritdoc />
    public partial class AdminEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Admin",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "User");
        }
    }
}
