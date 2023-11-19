using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWL.Migrations
{
    /// <inheritdoc />
    public partial class Adding_GPTApiKey_ToSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GPTApiKey",
                table: "Settings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GPTApiKey",
                table: "Settings");
        }
    }
}
