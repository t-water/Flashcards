using Microsoft.EntityFrameworkCore.Migrations;

namespace Flashcards.Data.Migrations
{
    public partial class AddedLanguageFamilyKeyToLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageFamilies_LanguageFamilyId",
                table: "Languages");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageFamilyId",
                table: "Languages",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageFamilies_LanguageFamilyId",
                table: "Languages",
                column: "LanguageFamilyId",
                principalTable: "LanguageFamilies",
                principalColumn: "LanguageFamilyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_LanguageFamilies_LanguageFamilyId",
                table: "Languages");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageFamilyId",
                table: "Languages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_LanguageFamilies_LanguageFamilyId",
                table: "Languages",
                column: "LanguageFamilyId",
                principalTable: "LanguageFamilies",
                principalColumn: "LanguageFamilyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
