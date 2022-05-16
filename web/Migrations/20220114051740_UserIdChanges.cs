using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class UserIdChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePerformed_AspNetUsers_userIdId",
                table: "ExercisePerformed");

            migrationBuilder.DropIndex(
                name: "IX_ExercisePerformed_userIdId",
                table: "ExercisePerformed");

            migrationBuilder.DropColumn(
                name: "userIdId",
                table: "ExercisePerformed");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "ExercisePerformed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "ExercisePerformed");

            migrationBuilder.AddColumn<string>(
                name: "userIdId",
                table: "ExercisePerformed",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePerformed_userIdId",
                table: "ExercisePerformed",
                column: "userIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePerformed_AspNetUsers_userIdId",
                table: "ExercisePerformed",
                column: "userIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
