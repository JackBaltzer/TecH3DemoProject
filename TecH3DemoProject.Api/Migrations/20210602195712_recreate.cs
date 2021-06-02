using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TecH3DemoProject.Api.Migrations
{
    public partial class recreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    Publised = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "FirstName", "LastName", "createdAt", "deletedAt", "updatedAt" },
                values: new object[] { 1, "Albert", "Andersen", new DateTime(2021, 6, 2, 21, 57, 11, 501, DateTimeKind.Local).AddTicks(4485), null, null });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "FirstName", "LastName", "createdAt", "deletedAt", "updatedAt" },
                values: new object[] { 2, "Benjamin", "Billiard", new DateTime(2021, 6, 2, 21, 57, 11, 505, DateTimeKind.Local).AddTicks(7412), null, null });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "Pages", "Publised", "Title", "createdAt", "deletedAt", "updatedAt" },
                values: new object[,]
                {
                    { 1, 1, 123, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "All The Books", new DateTime(2021, 6, 2, 21, 57, 11, 530, DateTimeKind.Local).AddTicks(9273), null, null },
                    { 3, 1, 32, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alphabet", new DateTime(2021, 6, 2, 21, 57, 11, 530, DateTimeKind.Local).AddTicks(9435), null, null },
                    { 2, 2, 321, new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Books are fun", new DateTime(2021, 6, 2, 21, 57, 11, 530, DateTimeKind.Local).AddTicks(9418), null, null },
                    { 4, 2, 91, new DateTime(1993, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bingo Bullshot", new DateTime(2021, 6, 2, 21, 57, 11, 530, DateTimeKind.Local).AddTicks(9445), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
