using Microsoft.EntityFrameworkCore.Migrations;

namespace GPP.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfession_AspNetUsers_ApplicationUserId",
                table: "UserProfession");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfession_Professions_professionId",
                table: "UserProfession");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfession",
                table: "UserProfession");

            migrationBuilder.RenameTable(
                name: "UserProfession",
                newName: "UserProfessions");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfession_ApplicationUserId",
                table: "UserProfessions",
                newName: "IX_UserProfessions_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfessions",
                table: "UserProfessions",
                columns: new[] { "professionId", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfessions_AspNetUsers_ApplicationUserId",
                table: "UserProfessions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfessions_Professions_professionId",
                table: "UserProfessions",
                column: "professionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfessions_AspNetUsers_ApplicationUserId",
                table: "UserProfessions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfessions_Professions_professionId",
                table: "UserProfessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfessions",
                table: "UserProfessions");

            migrationBuilder.RenameTable(
                name: "UserProfessions",
                newName: "UserProfession");

            migrationBuilder.RenameIndex(
                name: "IX_UserProfessions_ApplicationUserId",
                table: "UserProfession",
                newName: "IX_UserProfession_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfession",
                table: "UserProfession",
                columns: new[] { "professionId", "UserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfession_AspNetUsers_ApplicationUserId",
                table: "UserProfession",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfession_Professions_professionId",
                table: "UserProfession",
                column: "professionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
