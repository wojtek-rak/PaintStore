using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaintStore.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CommentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Content = table.Column<string>(unicode: false, nullable: false),
                    LikeCount = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    Edited = table.Column<bool>(nullable: true, defaultValueSql: "('0')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    UserOwnerName = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Title = table.Column<string>(unicode: false, nullable: false),
                    ImgLink = table.Column<string>(unicode: false, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Description = table.Column<string>(unicode: false, nullable: true),
                    LikeCount = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    ViewCount = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    CommentsCount = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    PopularActivity = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    NewestActivity = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    MixedActivity = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    Edited = table.Column<bool>(nullable: true, defaultValueSql: "('0')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TagName = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFollowers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FollowedUserId = table.Column<int>(nullable: false),
                    FollowingUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    PasswordSoil = table.Column<string>(unicode: false, nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, nullable: false),
                    Token = table.Column<string>(unicode: false, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(unicode: false, nullable: false),
                    Link = table.Column<string>(unicode: false, nullable: false),
                    AvatarImgLink = table.Column<string>(unicode: false, nullable: true),
                    BackgroundImgLink = table.Column<string>(unicode: false, nullable: true),
                    About = table.Column<string>(unicode: false, nullable: false),
                    PostsCount = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    FollowedCount = table.Column<int>(nullable: false, defaultValueSql: "('0')"),
                    FollowingCount = table.Column<int>(nullable: false, defaultValueSql: "('0')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Tags__BDE0FD1D5942FE60",
                table: "Tags",
                column: "TagName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentLikes");

            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "PostLikes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "UserFollowers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
