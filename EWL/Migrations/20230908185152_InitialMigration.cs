using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EWL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllWords",
                columns: table => new
                {
                    WordID = table.Column<long>(type: "INTEGER", nullable: false),
                    EngWord = table.Column<string>(type: "TEXT", nullable: false),
                    UaTranslation = table.Column<string>(type: "TEXT", nullable: false),
                    Rating = table.Column<long>(type: "INTEGER", nullable: false),
                    Repetition = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllWords", x => x.WordID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<byte[]>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    CanBeDeleted = table.Column<long>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<long>(type: "INTEGER", nullable: false),
                    DeletedAt = table.Column<byte[]>(type: "datetime", nullable: false, defaultValueSql: "'2000-01-01 00:00:00'")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingsID = table.Column<long>(type: "INTEGER", nullable: false),
                    WordCountToLearn = table.Column<long>(type: "INTEGER", nullable: false),
                    WasLaunched = table.Column<long>(type: "INTEGER", nullable: false),
                    WordAddingMode = table.Column<long>(type: "INTEGER", nullable: false),
                    CurrentCategoryID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingsID);
                    table.ForeignKey(
                        name: "FK_Settings_Categories_CurrentCategoryID",
                        column: x => x.CurrentCategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateTable(
                name: "WordCategories",
                columns: table => new
                {
                    WordID = table.Column<long>(type: "INTEGER", nullable: false),
                    CategoryID = table.Column<long>(type: "INTEGER", nullable: false),
                    AddedAt = table.Column<byte[]>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_WordCategories_AllWords_WordID",
                        column: x => x.WordID,
                        principalTable: "AllWords",
                        principalColumn: "WordID");
                    table.ForeignKey(
                        name: "FK_WordCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CurrentCategoryID",
                table: "Settings",
                column: "CurrentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_WordCategories_CategoryID",
                table: "WordCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_WordCategories_WordID",
                table: "WordCategories",
                column: "WordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "WordCategories");

            migrationBuilder.DropTable(
                name: "AllWords");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
