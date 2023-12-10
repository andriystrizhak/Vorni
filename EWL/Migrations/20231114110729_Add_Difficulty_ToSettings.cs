using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Difficulty_ToSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentDifficulty",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Settings");
        }
    }
}
