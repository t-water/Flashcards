using Microsoft.EntityFrameworkCore.Migrations;

namespace Flashcards.Data.Migrations
{
    public partial class AddedLanguageFamilies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageFamilyId",
                table: "Languages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LanguageFamilies",
                columns: table => new
                {
                    LanguageFamilyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageFamilies", x => x.LanguageFamilyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_LanguageFamilyId",
                table: "Languages",
                column: "LanguageFamilyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageFamilies_LanguageFamilyId",
                table: "Languages",
                column: "LanguageFamilyId",
                principalTable: "LanguageFamilies",
                principalColumn: "LanguageFamilyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageFamilies_LanguageFamilyId",
                table: "Languages");

            migrationBuilder.DropTable(
                name: "LanguageFamilies");

            migrationBuilder.DropIndex(
                name: "IX_Languages_LanguageFamilyId",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "LanguageFamilyId",
                table: "Languages");
        }
    }
}
