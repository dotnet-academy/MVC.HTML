using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesHub.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 40, nullable: true),
                    LastName = table.Column<string>(maxLength: 40, nullable: true),
                    ProfilePictureUrl = table.Column<string>(maxLength: 256, nullable: true),
                    ShortBio = table.Column<string>(maxLength: 256, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "ContentRating",
                columns: table => new
                {
                    ContentRatingId = table.Column<byte>(nullable: false),
                    Symbol = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 64, nullable: false),
                    LongDescription = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentRating", x => x.ContentRatingId);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(14, 2)", nullable: true),
                    PosterUrl = table.Column<string>(maxLength: 256, nullable: true),
                    VideoUrl = table.Column<string>(maxLength: 256, nullable: true),
                    VideoPosterUrl = table.Column<string>(maxLength: 256, nullable: true),
                    Summary = table.Column<string>(maxLength: 1024, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContentRatingId = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movie_ContentRating_ContentRatingId",
                        column: x => x.ContentRatingId,
                        principalTable: "ContentRating",
                        principalColumn: "ContentRatingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    Reviewer = table.Column<string>(maxLength: 100, nullable: false),
                    Text = table.Column<string>(maxLength: 1024, nullable: false),
                    Score = table.Column<decimal>(type: "decimal(3, 1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "AK_ContentRating_Name",
                table: "ContentRating",
                column: "Symbol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ContentRatingId",
                table: "Movie",
                column: "ContentRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorId",
                table: "MovieActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieId",
                table: "Review",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "ContentRating");
        }
    }
}
