using Microsoft.EntityFrameworkCore.Migrations;

namespace GPP.Migrations
{
    public partial class _22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gig_Profession_ProfessionId",
                table: "Gig");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfession_Profession_professionId",
                table: "UserProfession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profession",
                table: "Profession");

            migrationBuilder.RenameTable(
                name: "Profession",
                newName: "Professions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Professions",
                table: "Professions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gig_Professions_ProfessionId",
                table: "Gig",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfession_Professions_professionId",
                table: "UserProfession",
                column: "professionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gig_Professions_ProfessionId",
                table: "Gig");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfession_Professions_professionId",
                table: "UserProfession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Professions",
                table: "Professions");

            migrationBuilder.RenameTable(
                name: "Professions",
                newName: "Profession");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profession",
                table: "Profession",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gig_Profession_ProfessionId",
                table: "Gig",
                column: "ProfessionId",
                principalTable: "Profession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfession_Profession_professionId",
                table: "UserProfession",
                column: "professionId",
                principalTable: "Profession",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
