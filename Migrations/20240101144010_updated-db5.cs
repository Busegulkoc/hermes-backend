using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hermesTour.Migrations
{
    /// <inheritdoc />
    public partial class updateddb5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tourtraveler_Tours_TourstourId",
                table: "Tourtraveler");

            migrationBuilder.DropForeignKey(
                name: "FK_Tourtraveler_Travelers_TravelerListtravelerId",
                table: "Tourtraveler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tourtraveler",
                table: "Tourtraveler");

            migrationBuilder.RenameTable(
                name: "Tourtraveler",
                newName: "TravelerTours");

            migrationBuilder.RenameIndex(
                name: "IX_Tourtraveler_TravelerListtravelerId",
                table: "TravelerTours",
                newName: "IX_TravelerTours_TravelerListtravelerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelerTours",
                table: "TravelerTours",
                columns: new[] { "TourstourId", "TravelerListtravelerId" });

            migrationBuilder.CreateTable(
                name: "TravelerFavoriteTours",
                columns: table => new
                {
                    favoriteTourstourId = table.Column<int>(type: "int", nullable: false),
                    travelerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelerFavoriteTours", x => new { x.favoriteTourstourId, x.travelerId });
                    table.ForeignKey(
                        name: "FK_TravelerFavoriteTours_Tours_favoriteTourstourId",
                        column: x => x.favoriteTourstourId,
                        principalTable: "Tours",
                        principalColumn: "tourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelerFavoriteTours_Travelers_travelerId",
                        column: x => x.travelerId,
                        principalTable: "Travelers",
                        principalColumn: "travelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelerFavoriteTours_travelerId",
                table: "TravelerFavoriteTours",
                column: "travelerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelerTours_Tours_TourstourId",
                table: "TravelerTours",
                column: "TourstourId",
                principalTable: "Tours",
                principalColumn: "tourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelerTours_Travelers_TravelerListtravelerId",
                table: "TravelerTours",
                column: "TravelerListtravelerId",
                principalTable: "Travelers",
                principalColumn: "travelerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelerTours_Tours_TourstourId",
                table: "TravelerTours");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelerTours_Travelers_TravelerListtravelerId",
                table: "TravelerTours");

            migrationBuilder.DropTable(
                name: "TravelerFavoriteTours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelerTours",
                table: "TravelerTours");

            migrationBuilder.RenameTable(
                name: "TravelerTours",
                newName: "Tourtraveler");

            migrationBuilder.RenameIndex(
                name: "IX_TravelerTours_TravelerListtravelerId",
                table: "Tourtraveler",
                newName: "IX_Tourtraveler_TravelerListtravelerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tourtraveler",
                table: "Tourtraveler",
                columns: new[] { "TourstourId", "TravelerListtravelerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tourtraveler_Tours_TourstourId",
                table: "Tourtraveler",
                column: "TourstourId",
                principalTable: "Tours",
                principalColumn: "tourId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tourtraveler_Travelers_TravelerListtravelerId",
                table: "Tourtraveler",
                column: "TravelerListtravelerId",
                principalTable: "Travelers",
                principalColumn: "travelerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
