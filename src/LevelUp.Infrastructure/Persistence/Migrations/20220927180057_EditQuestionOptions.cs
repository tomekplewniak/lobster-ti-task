using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevelUp.Infrastructure.Persistence.Migrations
{
    public partial class EditQuestionOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_unknown",
                table: "question_options");

            migrationBuilder.DropColumn(
                name: "option_index",
                table: "question_options");

            migrationBuilder.DropColumn(
                name: "weight",
                table: "question_options");

            migrationBuilder.AddColumn<long>(
                name: "next_question_id",
                table: "question_options",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "next_question_id",
                table: "question_options");

            migrationBuilder.AddColumn<bool>(
                name: "is_unknown",
                table: "question_options",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "option_index",
                table: "question_options",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "weight",
                table: "question_options",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
