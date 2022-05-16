using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "ExercisePerformed");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "BodyWeight");

            migrationBuilder.AddColumn<string>(
                name: "userIdId",
                table: "Nutrition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userIdId",
                table: "ExercisePerformed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userIdId",
                table: "BodyWeight",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nutrition_userIdId",
                table: "Nutrition",
                column: "userIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ExercisePerformed_userIdId",
                table: "ExercisePerformed",
                column: "userIdId");

            migrationBuilder.CreateIndex(
                name: "IX_BodyWeight_userIdId",
                table: "BodyWeight",
                column: "userIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_BodyWeight_AspNetUsers_userIdId",
                table: "BodyWeight",
                column: "userIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExercisePerformed_AspNetUsers_userIdId",
                table: "ExercisePerformed",
                column: "userIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrition_AspNetUsers_userIdId",
                table: "Nutrition",
                column: "userIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BodyWeight_AspNetUsers_userIdId",
                table: "BodyWeight");

            migrationBuilder.DropForeignKey(
                name: "FK_ExercisePerformed_AspNetUsers_userIdId",
                table: "ExercisePerformed");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrition_AspNetUsers_userIdId",
                table: "Nutrition");

            migrationBuilder.DropIndex(
                name: "IX_Nutrition_userIdId",
                table: "Nutrition");

            migrationBuilder.DropIndex(
                name: "IX_ExercisePerformed_userIdId",
                table: "ExercisePerformed");

            migrationBuilder.DropIndex(
                name: "IX_BodyWeight_userIdId",
                table: "BodyWeight");

            migrationBuilder.DropColumn(
                name: "userIdId",
                table: "Nutrition");

            migrationBuilder.DropColumn(
                name: "userIdId",
                table: "ExercisePerformed");

            migrationBuilder.DropColumn(
                name: "userIdId",
                table: "BodyWeight");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Nutrition",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "ExercisePerformed",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "BodyWeight",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
