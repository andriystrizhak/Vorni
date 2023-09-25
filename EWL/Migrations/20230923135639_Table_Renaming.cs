using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eng_Flash_Cards_Learner.Migrations
{
    /// <inheritdoc />
    public partial class Table_Renaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Word",
                columns: table => new
                {
                    WordID = table.Column<long>(type: "INTEGER", nullable: false),
                    EngWord = table.Column<string>(type: "TEXT", nullable: false),
                    UaTranslation = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<long>(type: "INTEGER", nullable: false),
                    Repetition = table.Column<long>(type: "INTEGER", nullable: false),
                    Difficulty = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
