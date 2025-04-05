using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoEdu.Migrations
{
    /// <inheritdoc />
    public partial class addexamidtolecturemodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExamID",
                table: "lectures",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamID",
                table: "lectures");
        }
    }
}
