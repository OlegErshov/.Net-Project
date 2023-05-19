using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class DeleteHomeWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammaTasks_HomeWork_HomeWorkId",
                table: "GrammaTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertTasks_HomeWork_HomeWorkId",
                table: "InsertTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_SentenceTasks_HomeWork_HomeWorkId",
                table: "SentenceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_HomeWork_homeWorkId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_VocabluaryTasks_HomeWork_HomeWorkId",
                table: "VocabluaryTasks");

            migrationBuilder.DropTable(
                name: "HomeWork");

            migrationBuilder.DropIndex(
                name: "IX_VocabluaryTasks_HomeWorkId",
                table: "VocabluaryTasks");

            migrationBuilder.DropIndex(
                name: "IX_Students_homeWorkId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_SentenceTasks_HomeWorkId",
                table: "SentenceTasks");

            migrationBuilder.DropIndex(
                name: "IX_InsertTasks_HomeWorkId",
                table: "InsertTasks");

            migrationBuilder.DropIndex(
                name: "IX_GrammaTasks_HomeWorkId",
                table: "GrammaTasks");

            migrationBuilder.DropColumn(
                name: "HomeWorkId",
                table: "VocabluaryTasks");

            migrationBuilder.DropColumn(
                name: "HomeworkPath",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "homeWorkId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HomeWorkId",
                table: "SentenceTasks");

            migrationBuilder.DropColumn(
                name: "HomeWorkId",
                table: "InsertTasks");

            migrationBuilder.DropColumn(
                name: "HomeWorkId",
                table: "GrammaTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeWorkId",
                table: "VocabluaryTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomeworkPath",
                table: "Students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "homeWorkId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeWorkId",
                table: "SentenceTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeWorkId",
                table: "InsertTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeWorkId",
                table: "GrammaTasks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HomeWork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWork", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VocabluaryTasks_HomeWorkId",
                table: "VocabluaryTasks",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_homeWorkId",
                table: "Students",
                column: "homeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceTasks_HomeWorkId",
                table: "SentenceTasks",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_InsertTasks_HomeWorkId",
                table: "InsertTasks",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_GrammaTasks_HomeWorkId",
                table: "GrammaTasks",
                column: "HomeWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaTasks_HomeWork_HomeWorkId",
                table: "GrammaTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsertTasks_HomeWork_HomeWorkId",
                table: "InsertTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SentenceTasks_HomeWork_HomeWorkId",
                table: "SentenceTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_HomeWork_homeWorkId",
                table: "Students",
                column: "homeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VocabluaryTasks_HomeWork_HomeWorkId",
                table: "VocabluaryTasks",
                column: "HomeWorkId",
                principalTable: "HomeWork",
                principalColumn: "Id");
        }
    }
}
