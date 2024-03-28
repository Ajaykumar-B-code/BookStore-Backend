using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class customerfeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedBackTable",
                columns: table => new
                {
                    FeedBackID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CustomerRatings = table.Column<float>(nullable: false),
                    CustomerFeedback = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBackTable", x => x.FeedBackID);
                    table.ForeignKey(
                        name: "FK_FeedBackTable_BookTable_BookId",
                        column: x => x.BookId,
                        principalTable: "BookTable",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedBackTable_UserTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UserTable",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBackTable_BookId",
                table: "FeedBackTable",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBackTable_UserId",
                table: "FeedBackTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBackTable");
        }
    }
}
