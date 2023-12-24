using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hermesTour.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "CityCountry",
                columns: table => new
                {
                    cityCountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCountry", x => x.cityCountryId);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    tourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.tourId);
                });

            migrationBuilder.CreateTable(
                name: "TransportationVehicle",
                columns: table => new
                {
                    transportationVehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationVehicle", x => x.transportationVehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Travelers",
                columns: table => new
                {
                    travelerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    eMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wallet = table.Column<int>(type: "int", nullable: false),
                    vip = table.Column<bool>(type: "bit", nullable: false),
                    visa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travelers", x => x.travelerId);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    hotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.hotelId);
                    table.ForeignKey(
                        name: "FK_Hotels_CityCountry_cityCountryId",
                        column: x => x.cityCountryId,
                        principalTable: "CityCountry",
                        principalColumn: "cityCountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    managerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    cityCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.managerId);
                    table.ForeignKey(
                        name: "FK_Manager_CityCountry_cityCountryId",
                        column: x => x.cityCountryId,
                        principalTable: "CityCountry",
                        principalColumn: "cityCountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityCountryTour",
                columns: table => new
                {
                    CityCountryListcityCountryId = table.Column<int>(type: "int", nullable: false),
                    TourstourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCountryTour", x => new { x.CityCountryListcityCountryId, x.TourstourId });
                    table.ForeignKey(
                        name: "FK_CityCountryTour_CityCountry_CityCountryListcityCountryId",
                        column: x => x.CityCountryListcityCountryId,
                        principalTable: "CityCountry",
                        principalColumn: "cityCountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityCountryTour_Tours_TourstourId",
                        column: x => x.TourstourId,
                        principalTable: "Tours",
                        principalColumn: "tourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourTransportationVehicle",
                columns: table => new
                {
                    TourstourId = table.Column<int>(type: "int", nullable: false),
                    TransportationVehicleListtransportationVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourTransportationVehicle", x => new { x.TourstourId, x.TransportationVehicleListtransportationVehicleId });
                    table.ForeignKey(
                        name: "FK_TourTransportationVehicle_Tours_TourstourId",
                        column: x => x.TourstourId,
                        principalTable: "Tours",
                        principalColumn: "tourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourTransportationVehicle_TransportationVehicle_TransportationVehicleListtransportationVehicleId",
                        column: x => x.TransportationVehicleListtransportationVehicleId,
                        principalTable: "TransportationVehicle",
                        principalColumn: "transportationVehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportationWorkers",
                columns: table => new
                {
                    transportationWorkersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transportationVehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationWorkers", x => x.transportationWorkersId);
                    table.ForeignKey(
                        name: "FK_TransportationWorkers_TransportationVehicle_transportationVehicleId",
                        column: x => x.transportationVehicleId,
                        principalTable: "TransportationVehicle",
                        principalColumn: "transportationVehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    commentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    travelerId = table.Column<int>(type: "int", nullable: false),
                    tourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_Comments_Tours_tourId",
                        column: x => x.tourId,
                        principalTable: "Tours",
                        principalColumn: "tourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Travelers_travelerId",
                        column: x => x.travelerId,
                        principalTable: "Travelers",
                        principalColumn: "travelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tourtraveler",
                columns: table => new
                {
                    TourstourId = table.Column<int>(type: "int", nullable: false),
                    TravelerListtravelerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourtraveler", x => new { x.TourstourId, x.TravelerListtravelerId });
                    table.ForeignKey(
                        name: "FK_Tourtraveler_Tours_TourstourId",
                        column: x => x.TourstourId,
                        principalTable: "Tours",
                        principalColumn: "tourId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tourtraveler_Travelers_TravelerListtravelerId",
                        column: x => x.TravelerListtravelerId,
                        principalTable: "Travelers",
                        principalColumn: "travelerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelTour",
                columns: table => new
                {
                    HotelListhotelId = table.Column<int>(type: "int", nullable: false),
                    TourstourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTour", x => new { x.HotelListhotelId, x.TourstourId });
                    table.ForeignKey(
                        name: "FK_HotelTour_Hotels_HotelListhotelId",
                        column: x => x.HotelListhotelId,
                        principalTable: "Hotels",
                        principalColumn: "hotelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelTour_Tours_TourstourId",
                        column: x => x.TourstourId,
                        principalTable: "Tours",
                        principalColumn: "tourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityCountryTour_TourstourId",
                table: "CityCountryTour",
                column: "TourstourId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_tourId",
                table: "Comments",
                column: "tourId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_travelerId",
                table: "Comments",
                column: "travelerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_cityCountryId",
                table: "Hotels",
                column: "cityCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelTour_TourstourId",
                table: "HotelTour",
                column: "TourstourId");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_cityCountryId",
                table: "Manager",
                column: "cityCountryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourTransportationVehicle_TransportationVehicleListtransportationVehicleId",
                table: "TourTransportationVehicle",
                column: "TransportationVehicleListtransportationVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourtraveler_TravelerListtravelerId",
                table: "Tourtraveler",
                column: "TravelerListtravelerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportationWorkers_transportationVehicleId",
                table: "TransportationWorkers",
                column: "transportationVehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "CityCountryTour");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "HotelTour");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "TourTransportationVehicle");

            migrationBuilder.DropTable(
                name: "Tourtraveler");

            migrationBuilder.DropTable(
                name: "TransportationWorkers");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Travelers");

            migrationBuilder.DropTable(
                name: "TransportationVehicle");

            migrationBuilder.DropTable(
                name: "CityCountry");
        }
    }
}
