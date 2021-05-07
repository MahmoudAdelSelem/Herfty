using Microsoft.EntityFrameworkCore.Migrations;

namespace GPP.Migrations
{
    public partial class Profession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfessions");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfessionId",
                table: "AspNetUsers",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Professions_ProfessionId",
                table: "AspNetUsers",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Professions_ProfessionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfessionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserProfessions",
                columns: table => new
                {
                    professionId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfessions", x => new { x.professionId, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserProfessions_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfessions_Professions_professionId",
                        column: x => x.professionId,
                        principalTable: "Professions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfessions_ApplicationUserId",
                table: "UserProfessions",
                column: "ApplicationUserId");
        }
    }
}
