using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecKaliteDb.Migrations
{
    /// <inheritdoc />
    public partial class SifreUnuttumRegisterlaBaglandı : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TC",
                table: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TC",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
