using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FYPSystem.Data.Migrations
{
    public partial class abcd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderStudentSection",
                table: "StudentRequestForSupervisorIdeas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderStudentSection",
                table: "StudentRequestForSupervisorIdeas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
