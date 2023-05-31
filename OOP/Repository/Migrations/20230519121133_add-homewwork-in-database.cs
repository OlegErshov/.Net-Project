using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addhomewworkindatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeWorks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeWorks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrammaTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomeWorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammaTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrammaTask_HomeWorks_HomeWorkId",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsertTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    words = table.Column<string>(type: "TEXT", nullable: false),
                    HomeWorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsertTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsertTask_HomeWorks_HomeWorkId",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SentenceTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomeWorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentenceTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentenceTask_HomeWorks_HomeWorkId",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VocabluaryTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HomeWorkId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabluaryTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabluaryTask_HomeWorks_HomeWorkId",
                        column: x => x.HomeWorkId,
                        principalTable: "HomeWorks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrammaQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sentence = table.Column<string>(type: "TEXT", nullable: false),
                    rightAnswer = table.Column<string>(type: "TEXT", nullable: false),
                    GrammaTaskId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrammaQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrammaQuestion_GrammaTask_GrammaTaskId",
                        column: x => x.GrammaTaskId,
                        principalTable: "GrammaTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsertQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    word = table.Column<string>(type: "TEXT", nullable: true),
                    sentence = table.Column<string>(type: "TEXT", nullable: true),
                    InsertTaskId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsertQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsertQuestion_InsertTask_InsertTaskId",
                        column: x => x.InsertTaskId,
                        principalTable: "InsertTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SentenceQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Words = table.Column<string>(type: "TEXT", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", nullable: true),
                    SentenceTaskId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentenceQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentenceQuestion_SentenceTask_SentenceTaskId",
                        column: x => x.SentenceTaskId,
                        principalTable: "SentenceTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VocabluaryQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    letters = table.Column<string>(type: "TEXT", nullable: true),
                    answer = table.Column<string>(type: "TEXT", nullable: true),
                    VocabluaryTaskId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabluaryQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabluaryQuestion_VocabluaryTask_VocabluaryTaskId",
                        column: x => x.VocabluaryTaskId,
                        principalTable: "VocabluaryTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrammaQuestion_GrammaTaskId",
                table: "GrammaQuestion",
                column: "GrammaTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_GrammaTask_HomeWorkId",
                table: "GrammaTask",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_InsertQuestion_InsertTaskId",
                table: "InsertQuestion",
                column: "InsertTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_InsertTask_HomeWorkId",
                table: "InsertTask",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceQuestion_SentenceTaskId",
                table: "SentenceQuestion",
                column: "SentenceTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_SentenceTask_HomeWorkId",
                table: "SentenceTask",
                column: "HomeWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabluaryQuestion_VocabluaryTaskId",
                table: "VocabluaryQuestion",
                column: "VocabluaryTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabluaryTask_HomeWorkId",
                table: "VocabluaryTask",
                column: "HomeWorkId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrammaQuestion");

            migrationBuilder.DropTable(
                name: "InsertQuestion");

            migrationBuilder.DropTable(
                name: "SentenceQuestion");

            migrationBuilder.DropTable(
                name: "VocabluaryQuestion");

            migrationBuilder.DropTable(
                name: "GrammaTask");

            migrationBuilder.DropTable(
                name: "InsertTask");

            migrationBuilder.DropTable(
                name: "SentenceTask");

            migrationBuilder.DropTable(
                name: "VocabluaryTask");

            migrationBuilder.DropTable(
                name: "HomeWorks");
        }
    }
}
