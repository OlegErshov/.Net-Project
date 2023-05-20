using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class NullableFieldInInsertTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammaTasks_Students_StudentId",
                table: "GrammaTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertQuestion_InsertTasks_InsertTaskId",
                table: "InsertQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertTasks_Students_StudentId",
                table: "InsertTasks");

            migrationBuilder.DropIndex(
                name: "IX_InsertQuestion_InsertTaskId",
                table: "InsertQuestion");

            migrationBuilder.DropColumn(
                name: "InsertTaskId",
                table: "InsertQuestion");

            migrationBuilder.AlterColumn<string>(
                name: "words",
                table: "InsertTasks",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "InsertTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "taskId",
                table: "InsertQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "GrammaTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsertQuestion_taskId",
                table: "InsertQuestion",
                column: "taskId");

            migrationBuilder.AddForeignKey(
                name: "FK_GrammaTasks_Students_StudentId",
                table: "GrammaTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsertQuestion_InsertTasks_taskId",
                table: "InsertQuestion",
                column: "taskId",
                principalTable: "InsertTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsertTasks_Students_StudentId",
                table: "InsertTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrammaTasks_Students_StudentId",
                table: "GrammaTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertQuestion_InsertTasks_taskId",
                table: "InsertQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_InsertTasks_Students_StudentId",
                table: "InsertTasks");

            migrationBuilder.DropIndex(
                name: "IX_InsertQuestion_taskId",
                table: "InsertQuestion");

            migrationBuilder.DropColumn(
                name: "taskId",
                table: "InsertQuestion");

            migrationBuilder.AlterColumn<string>(
                name: "words",
                table: "InsertTasks",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "InsertTasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "InsertTaskId",
                table: "InsertQuestion",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "GrammaTasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_InsertQuestion_InsertTaskId",
                table: "InsertQuestion",
                column: "InsertTaskId");

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
                name: "FK_InsertTasks_Students_StudentId",
                table: "InsertTasks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
