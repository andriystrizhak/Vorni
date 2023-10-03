using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWL.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Difficulty_ToAllWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "AllWords",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "AllWords");
        }
    }
}
