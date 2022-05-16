using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exerciseId",
                table: "ExercisePerformed");

            migrationBuilder.AddColumn<string>(
                name: "exerciseName",
                table: "ExercisePerformed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "exerciseName",
                table: "ExercisePerformed");

            migrationBuilder.AddColumn<int>(
                name: "exerciseId",
                table: "ExercisePerformed",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
