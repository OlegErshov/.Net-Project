using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class newStructureOfDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammaQuestion_GrammaTask_GrammaTaskId",
                table: "GrammaQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_GrammaTask_HomeWorks_HomeWorkId",
                table: "GrammaTask");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertQuestion_InsertTask_InsertTaskId",
                table: "InsertQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertTask_HomeWorks_HomeWorkId",
                table: "InsertTask");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceQuestion_SentenceTask_SentenceTaskId",
                table: "SentenceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceTask_HomeWorks_HomeWorkId",
                table: "SentenceTask");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTask_VocabluaryTaskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryTask_HomeWorks_HomeWorkId",
                table: "VocabluaryTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VocabluaryTask",
                table: "VocabluaryTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SentenceTask",
                table: "SentenceTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsertTask",
                table: "InsertTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeWorks",
                table: "HomeWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrammaTask",
                table: "GrammaTask");

            migrationBuilder.RenameTable(
                name: "VocabluaryTask",
                newName: "VocabluaryTasks");

            migrationBuilder.RenameTable(
                name: "SentenceTask",
                newName: "SentenceTasks");

            migrationBuilder.RenameTable(
                name: "InsertTask",
                newName: "InsertTasks");

            migrationBuilder.RenameTable(
                name: "HomeWorks",
                newName: "HomeWork");

            migrationBuilder.RenameTable(
                name: "GrammaTask",
                newName: "GrammaTasks");

            migrationBuilder.RenameIndex(
                name: "IX_VocabluaryTask_HomeWorkId",
                table: "VocabluaryTasks",
                newName: "IX_VocabluaryTasks_HomeWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_SentenceTask_HomeWorkId",
                table: "SentenceTasks",
                newName: "IX_SentenceTasks_HomeWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_InsertTask_HomeWorkId",
                table: "InsertTasks",
                newName: "IX_InsertTasks_HomeWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_GrammaTask_HomeWorkId",
                table: "GrammaTasks",
                newName: "IX_GrammaTasks_HomeWorkId");

            migrationBuilder.AddColumn<int>(
                name: "homeWorkId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "VocabluaryTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "SentenceTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "InsertTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "GrammaTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VocabluaryTasks",
                table: "VocabluaryTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SentenceTasks",
                table: "SentenceTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsertTasks",
                table: "InsertTasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeWork",
                table: "HomeWork",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrammaTasks",
                table: "GrammaTasks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_homeWorkId",
                table: "Students",
                column: "homeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabluaryTasks_StudentId",
                table: "VocabluaryTasks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceTasks_StudentId",
                table: "SentenceTasks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_InsertTasks_StudentId",
                table: "InsertTasks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_GrammaTasks_StudentId",
                table: "GrammaTasks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaQuestion_GrammaTasks_GrammaTaskId",
                table: "GrammaQuestion",
                column: "GrammaTaskId",
                principalTable: "GrammaTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaTasks_HomeWork_HomeWorkId",
                table: "GrammaTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaTasks_Students_StudentId",
                table: "GrammaTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsertQuestion_InsertTasks_InsertTaskId",
                table: "InsertQuestion",
                column: "InsertTaskId",
                principalTable: "InsertTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsertTasks_HomeWork_HomeWorkId",
                table: "InsertTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsertTasks_Students_StudentId",
                table: "InsertTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceQuestion_SentenceTasks_SentenceTaskId",
                table: "SentenceQuestion",
                column: "SentenceTaskId",
                principalTable: "SentenceTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceTasks_HomeWork_HomeWorkId",
                table: "SentenceTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceTasks_Students_StudentId",
                table: "SentenceTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_HomeWork_homeWorkId",
                table: "Students",
                column: "homeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTasks_VocabluaryTaskId",
                table: "VocabluaryQuestion",
                column: "VocabluaryTaskId",
                principalTable: "VocabluaryTasks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryTasks_HomeWork_HomeWorkId",
                table: "VocabluaryTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryTasks_Students_StudentId",
                table: "VocabluaryTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammaQuestion_GrammaTasks_GrammaTaskId",
                table: "GrammaQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_GrammaTasks_HomeWork_HomeWorkId",
                table: "GrammaTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_GrammaTasks_Students_StudentId",
                table: "GrammaTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertQuestion_InsertTasks_InsertTaskId",
                table: "InsertQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertTasks_HomeWork_HomeWorkId",
                table: "InsertTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertTasks_Students_StudentId",
                table: "InsertTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceQuestion_SentenceTasks_SentenceTaskId",
                table: "SentenceQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceTasks_HomeWork_HomeWorkId",
                table: "SentenceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceTasks_Students_StudentId",
                table: "SentenceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_HomeWork_homeWorkId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTasks_VocabluaryTaskId",
                table: "VocabluaryQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryTasks_HomeWork_HomeWorkId",
                table: "VocabluaryTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryTasks_Students_StudentId",
                table: "VocabluaryTasks");

            migrationBuilder.DropIndex(
                name: "IX_Students_homeWorkId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VocabluaryTasks",
                table: "VocabluaryTasks");

            migrationBuilder.DropIndex(
                name: "IX_VocabluaryTasks_StudentId",
                table: "VocabluaryTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SentenceTasks",
                table: "SentenceTasks");

            migrationBuilder.DropIndex(
                name: "IX_SentenceTasks_StudentId",
                table: "SentenceTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsertTasks",
                table: "InsertTasks");

            migrationBuilder.DropIndex(
                name: "IX_InsertTasks_StudentId",
                table: "InsertTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HomeWork",
                table: "HomeWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrammaTasks",
                table: "GrammaTasks");

            migrationBuilder.DropIndex(
                name: "IX_GrammaTasks_StudentId",
                table: "GrammaTasks");

            migrationBuilder.DropColumn(
                name: "homeWorkId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "VocabluaryTasks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "SentenceTasks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "InsertTasks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "GrammaTasks");

            migrationBuilder.RenameTable(
                name: "VocabluaryTasks",
                newName: "VocabluaryTask");

            migrationBuilder.RenameTable(
                name: "SentenceTasks",
                newName: "SentenceTask");

            migrationBuilder.RenameTable(
                name: "InsertTasks",
                newName: "InsertTask");

            migrationBuilder.RenameTable(
                name: "HomeWork",
                newName: "HomeWorks");

            migrationBuilder.RenameTable(
                name: "GrammaTasks",
                newName: "GrammaTask");

            migrationBuilder.RenameIndex(
                name: "IX_VocabluaryTasks_HomeWorkId",
                table: "VocabluaryTask",
                newName: "IX_VocabluaryTask_HomeWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_SentenceTasks_HomeWorkId",
                table: "SentenceTask",
                newName: "IX_SentenceTask_HomeWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_InsertTasks_HomeWorkId",
                table: "InsertTask",
                newName: "IX_InsertTask_HomeWorkId");

            migrationBuilder.RenameIndex(
                name: "IX_GrammaTasks_HomeWorkId",
                table: "GrammaTask",
                newName: "IX_GrammaTask_HomeWorkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VocabluaryTask",
                table: "VocabluaryTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SentenceTask",
                table: "SentenceTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsertTask",
                table: "InsertTask",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HomeWorks",
                table: "HomeWorks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrammaTask",
                table: "GrammaTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaQuestion_GrammaTask_GrammaTaskId",
                table: "GrammaQuestion",
                column: "GrammaTaskId",
                principalTable: "GrammaTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaTask_HomeWorks_HomeWorkId",
                table: "GrammaTask",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsertQuestion_InsertTask_InsertTaskId",
                table: "InsertQuestion",
                column: "InsertTaskId",
                principalTable: "InsertTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsertTask_HomeWorks_HomeWorkId",
                table: "InsertTask",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceQuestion_SentenceTask_SentenceTaskId",
                table: "SentenceQuestion",
                column: "SentenceTaskId",
                principalTable: "SentenceTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceTask_HomeWorks_HomeWorkId",
                table: "SentenceTask",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryQuestion_VocabluaryTask_VocabluaryTaskId",
                table: "VocabluaryQuestion",
                column: "VocabluaryTaskId",
                principalTable: "VocabluaryTask",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryTask_HomeWorks_HomeWorkId",
                table: "VocabluaryTask",
                column: "HomeWorkId",
                principalTable: "HomeWorks",
                principalColumn: "Id");
        }
    }
}
