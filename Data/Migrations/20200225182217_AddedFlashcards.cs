using Microsoft.EntityFrameworkCore.Migrations;

namespace Flashcards.Data.Migrations
{
    public partial class AddedFlashcards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    FlashcardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Word = table.Column<string>(nullable: false),
                    EnglishTranslation = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    PartOfSpeech = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: true),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.FlashcardId);
                    table.ForeignKey(
                        name: "FK_Flashcards_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_LanguageId",
                table: "Flashcards",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flashcards");
        }
    }
}
