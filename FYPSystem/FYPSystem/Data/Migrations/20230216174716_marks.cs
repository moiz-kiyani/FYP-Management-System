using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYPSystem.Data.Migrations
{
    public partial class marks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RollNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProposalMarks = table.Column<float>(type: "real", nullable: false),
                    PosterMarks = table.Column<float>(type: "real", nullable: false),
                    SupervisorMarks = table.Column<float>(type: "real", nullable: false),
                    ExaminerOne = table.Column<float>(type: "real", nullable: false),
                    ExaminerTwo = table.Column<float>(type: "real", nullable: false),
                    TotalMarks = table.Column<float>(type: "real", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: false),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupervisorEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluatorOneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvaluatorTwoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_StudentId",
                table: "Evaluation",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluation");
        }
    }
}
