using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addMarks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeacherId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "RightOrNot",
                table: "VocabluaryQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RightOrNot",
                table: "SentenceQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RightOrNot",
                table: "InsertQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RightOrNot",
                table: "GrammaQuestion",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    mark = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mark_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mark_StudentId",
                table: "Mark",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeacherId",
                table: "AspNetUsers",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeacherId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropColumn(
                name: "RightOrNot",
                table: "VocabluaryQuestion");

            migrationBuilder.DropColumn(
                name: "RightOrNot",
                table: "SentenceQuestion");

            migrationBuilder.DropColumn(
                name: "RightOrNot",
                table: "InsertQuestion");

            migrationBuilder.DropColumn(
                name: "RightOrNot",
                table: "GrammaQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_TeacherId",
                table: "AspNetUsers",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
