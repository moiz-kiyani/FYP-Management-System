using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYPSystem.Data.Migrations
{
    public partial class saaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EvaluatorOneName",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "EvaluatorTwoName",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "ExaminerOne",
                table: "Evaluation");

            migrationBuilder.DropColumn(
                name: "ExaminerTwo",
                table: "Evaluation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EvaluatorOneName",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EvaluatorTwoName",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "ExaminerOne",
                table: "Evaluation",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ExaminerTwo",
                table: "Evaluation",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
