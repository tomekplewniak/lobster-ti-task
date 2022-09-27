using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LevelUp.Infrastructure.Persistence.Migrations
{
    public partial class AddNextQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_question_options_next_question_id",
                table: "question_options",
                column: "next_question_id");

            migrationBuilder.AddForeignKey(
                name: "fk_question_options_questions_next_question_id",
                table: "question_options",
                column: "next_question_id",
                principalTable: "questions",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_question_options_questions_next_question_id",
                table: "question_options");

            migrationBuilder.DropIndex(
                name: "ix_question_options_next_question_id",
                table: "question_options");
        }
    }
}
