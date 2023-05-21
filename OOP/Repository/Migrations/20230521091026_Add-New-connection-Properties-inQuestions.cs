using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddNewconnectionPropertiesinQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SentenceQuestion_SentenceTasks_SentenceTaskId",
                table: "SentenceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceTasks_Students_StudentId",
                table: "SentenceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTasks_VocabluaryTaskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryTasks_Students_StudentId",
                table: "VocabluaryTasks");

            migrationBuilder.DropIndex(
                name: "IX_VocabluaryQuestion_VocabluaryTaskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropIndex(
                name: "IX_SentenceQuestion_SentenceTaskId",
                table: "SentenceQuestion");

            migrationBuilder.DropColumn(
                name: "VocabluaryTaskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropColumn(
                name: "SentenceTaskId",
                table: "SentenceQuestion");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "VocabluaryTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "taskId",
                table: "VocabluaryQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "SentenceTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "taskId",
                table: "SentenceQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VocabluaryQuestion_taskId",
                table: "VocabluaryQuestion",
                column: "taskId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceQuestion_taskId",
                table: "SentenceQuestion",
                column: "taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceQuestion_SentenceTasks_taskId",
                table: "SentenceQuestion",
                column: "taskId",
                principalTable: "SentenceTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceTasks_Students_StudentId",
                table: "SentenceTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTasks_taskId",
                table: "VocabluaryQuestion",
                column: "taskId",
                principalTable: "VocabluaryTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryTasks_Students_StudentId",
                table: "VocabluaryTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SentenceQuestion_SentenceTasks_taskId",
                table: "SentenceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceTasks_Students_StudentId",
                table: "SentenceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTasks_taskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryTasks_Students_StudentId",
                table: "VocabluaryTasks");

            migrationBuilder.DropIndex(
                name: "IX_VocabluaryQuestion_taskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropIndex(
                name: "IX_SentenceQuestion_taskId",
                table: "SentenceQuestion");

            migrationBuilder.DropColumn(
                name: "taskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropColumn(
                name: "taskId",
                table: "SentenceQuestion");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "VocabluaryTasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "VocabluaryTaskId",
                table: "VocabluaryQuestion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "SentenceTasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "SentenceTaskId",
                table: "SentenceQuestion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabluaryQuestion_VocabluaryTaskId",
                table: "VocabluaryQuestion",
                column: "VocabluaryTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceQuestion_SentenceTaskId",
                table: "SentenceQuestion",
                column: "SentenceTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceQuestion_SentenceTasks_SentenceTaskId",
                table: "SentenceQuestion",
                column: "SentenceTaskId",
                principalTable: "SentenceTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceTasks_Students_StudentId",
                table: "SentenceTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTasks_VocabluaryTaskId",
                table: "VocabluaryQuestion",
                column: "VocabluaryTaskId",
                principalTable: "VocabluaryTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryTasks_Students_StudentId",
                table: "VocabluaryTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
