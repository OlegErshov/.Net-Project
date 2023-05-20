using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addnewkeyproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammaQuestion_GrammaTasks_GrammaTaskId",
                table: "GrammaQuestion");

            migrationBuilder.DropIndex(
                name: "IX_GrammaQuestion_GrammaTaskId",
                table: "GrammaQuestion");

            migrationBuilder.DropColumn(
                name: "answer",
                table: "VocabluaryQuestion");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "SentenceQuestion");

            migrationBuilder.DropColumn(
                name: "word",
                table: "InsertQuestion");

            migrationBuilder.DropColumn(
                name: "GrammaTaskId",
                table: "GrammaQuestion");

            migrationBuilder.RenameColumn(
                name: "sentence",
                table: "InsertQuestion",
                newName: "Sentence");

            migrationBuilder.RenameColumn(
                name: "rightAnswer",
                table: "GrammaQuestion",
                newName: "StringAnswer");

            migrationBuilder.AddColumn<string>(
                name: "StringAnswer",
                table: "VocabluaryQuestion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StringAnswer",
                table: "SentenceQuestion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StringAnswer",
                table: "InsertQuestion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnswerVarients",
                table: "GrammaQuestion",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "taskId",
                table: "GrammaQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GrammaQuestion_taskId",
                table: "GrammaQuestion",
                column: "taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaQuestion_GrammaTasks_taskId",
                table: "GrammaQuestion",
                column: "taskId",
                principalTable: "GrammaTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammaQuestion_GrammaTasks_taskId",
                table: "GrammaQuestion");

            migrationBuilder.DropIndex(
                name: "IX_GrammaQuestion_taskId",
                table: "GrammaQuestion");

            migrationBuilder.DropColumn(
                name: "StringAnswer",
                table: "VocabluaryQuestion");

            migrationBuilder.DropColumn(
                name: "StringAnswer",
                table: "SentenceQuestion");

            migrationBuilder.DropColumn(
                name: "StringAnswer",
                table: "InsertQuestion");

            migrationBuilder.DropColumn(
                name: "AnswerVarients",
                table: "GrammaQuestion");

            migrationBuilder.DropColumn(
                name: "taskId",
                table: "GrammaQuestion");

            migrationBuilder.RenameColumn(
                name: "Sentence",
                table: "InsertQuestion",
                newName: "sentence");

            migrationBuilder.RenameColumn(
                name: "StringAnswer",
                table: "GrammaQuestion",
                newName: "rightAnswer");

            migrationBuilder.AddColumn<string>(
                name: "answer",
                table: "VocabluaryQuestion",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "SentenceQuestion",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "word",
                table: "InsertQuestion",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrammaTaskId",
                table: "GrammaQuestion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GrammaQuestion_GrammaTaskId",
                table: "GrammaQuestion",
                column: "GrammaTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaQuestion_GrammaTasks_GrammaTaskId",
                table: "GrammaQuestion",
                column: "GrammaTaskId",
                principalTable: "GrammaTasks",
                principalColumn: "Id");
        }
    }
}
