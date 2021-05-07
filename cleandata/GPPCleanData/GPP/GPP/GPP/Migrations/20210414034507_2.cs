using Microsoft.EntityFrameworkCore.Migrations;

namespace GPP.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gig_AspNetUsers_UserId",
                table: "Gig");

            migrationBuilder.DropForeignKey(
                name: "FK_Gig_Professions_ProfessionId",
                table: "Gig");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gig",
                table: "Gig");

            migrationBuilder.RenameTable(
                name: "Gig",
                newName: "Gigs");

            migrationBuilder.RenameIndex(
                name: "IX_Gig_UserId",
                table: "Gigs",
                newName: "IX_Gigs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Gig_ProfessionId",
                table: "Gigs",
                newName: "IX_Gigs_ProfessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gigs",
                table: "Gigs",
                column: "GigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_AspNetUsers_UserId",
                table: "Gigs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gigs_Professions_ProfessionId",
                table: "Gigs",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_AspNetUsers_UserId",
                table: "Gigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gigs_Professions_ProfessionId",
                table: "Gigs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gigs",
                table: "Gigs");

            migrationBuilder.RenameTable(
                name: "Gigs",
                newName: "Gig");

            migrationBuilder.RenameIndex(
                name: "IX_Gigs_UserId",
                table: "Gig",
                newName: "IX_Gig_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Gigs_ProfessionId",
                table: "Gig",
                newName: "IX_Gig_ProfessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gig",
                table: "Gig",
                column: "GigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gig_AspNetUsers_UserId",
                table: "Gig",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gig_Professions_ProfessionId",
                table: "Gig",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
