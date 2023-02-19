using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYPSystem.Data.Migrations
{
    public partial class upppppp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "DecisionStatus",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "Proposal",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "RecieverSupervisorName",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "SenderStudentEmail",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "SenderStudentId",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "SenderStudentName",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "SenderStudentRollNo",
                table: "StudentIdeas");

            migrationBuilder.RenameColumn(
                name: "RecieverSupervisorID",
                table: "StudentIdeas",
                newName: "StudentId");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentRollNo",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdeas_StudentId",
                table: "StudentIdeas",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentIdeas_Student_StudentId",
                table: "StudentIdeas",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentIdeas_Student_StudentId",
                table: "StudentIdeas");

            migrationBuilder.DropIndex(
                name: "IX_StudentIdeas_StudentId",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "StudentIdeas");

            migrationBuilder.DropColumn(
                name: "StudentRollNo",
                table: "StudentIdeas");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "StudentIdeas",
                newName: "RecieverSupervisorID");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionStatus",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Proposal",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecieverSupervisorName",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderStudentEmail",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SenderStudentId",
                table: "StudentIdeas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderStudentName",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderStudentRollNo",
                table: "StudentIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
