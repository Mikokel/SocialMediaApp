using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RevConnectAPI.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RevConnect");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "RevConnect",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    password = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    aboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "RevConnect",
                columns: table => new
                {
                    postID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.postID);
                    table.ForeignKey(
                        name: "FK_Post_User_userID",
                        column: x => x.userID,
                        principalSchema: "RevConnect",
                        principalTable: "User",
                        principalColumn: "userID");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "RevConnect",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comment_Post_postID",
                        column: x => x.postID,
                        principalSchema: "RevConnect",
                        principalTable: "Post",
                        principalColumn: "postID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_userID",
                        column: x => x.userID,
                        principalSchema: "RevConnect",
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                schema: "RevConnect",
                columns: table => new
                {
                    likeID = table.Column<int>(type: "int", maxLength: 256, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    postID = table.Column<int>(type: "int", nullable: true),
                    commentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.likeID);
                    table.ForeignKey(
                        name: "FK_Like_Comment_commentID",
                        column: x => x.commentID,
                        principalSchema: "RevConnect",
                        principalTable: "Comment",
                        principalColumn: "commentID");
                    table.ForeignKey(
                        name: "FK_Like_Post_postID",
                        column: x => x.postID,
                        principalSchema: "RevConnect",
                        principalTable: "Post",
                        principalColumn: "postID");
                    table.ForeignKey(
                        name: "FK_Like_User_userID",
                        column: x => x.userID,
                        principalSchema: "RevConnect",
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_postID",
                schema: "RevConnect",
                table: "Comment",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_userID",
                schema: "RevConnect",
                table: "Comment",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_commentID",
                schema: "RevConnect",
                table: "Like",
                column: "commentID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_postID",
                schema: "RevConnect",
                table: "Like",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_Like_userID",
                schema: "RevConnect",
                table: "Like",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_userID",
                schema: "RevConnect",
                table: "Post",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like",
                schema: "RevConnect");

            migrationBuilder.DropTable(
                name: "Comment",
                schema: "RevConnect");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "RevConnect");

            migrationBuilder.DropTable(
                name: "User",
                schema: "RevConnect");
        }
    }
}
