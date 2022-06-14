using Microsoft.EntityFrameworkCore.Migrations;

namespace RebelTours.Persistence.Migrations
{
    public partial class WithBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    BusManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SeatCapacity = table.Column<int>(type: "int", nullable: false),
                    HasToilet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusModels_BusManufacturers_BusManufacturerId",
                        column: x => x.BusManufacturerId,
                        principalTable: "BusManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusModelId = table.Column<int>(type: "int", nullable: false),
                    RegistrationPlate = table.Column<string>(type: "varchar(100)", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    SeatMapping = table.Column<int>(type: "int", nullable: false),
                    DistanceTraveled = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_BusModels_BusModelId",
                        column: x => x.BusModelId,
                        principalTable: "BusModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusManufacturers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mercedes" },
                    { 2, "MAN" },
                    { 3, "Volvo" },
                    { 4, "Renault" },
                    { 5, "Togg" },
                    { 6, "Karsan" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "İstanbul" },
                    { 2, "İzmir" },
                    { 3, "Mersin" },
                    { 4, "Giresun" },
                    { 5, "Adana" }
                });

            migrationBuilder.InsertData(
                table: "BusModels",
                columns: new[] { "Id", "BusManufacturerId", "HasToilet", "Name", "SeatCapacity", "Type" },
                values: new object[,]
                {
                    { 1, 1, true, "Tourismo", 44, 2 },
                    { 2, 1, true, "Travego", 48, 2 },
                    { 3, 1, true, "CapaCity", 52, 2 },
                    { 7, 2, true, "XLarge", 48, 2 },
                    { 4, 4, false, "Escape", 26, 1 },
                    { 6, 5, true, "Super", 34, 1 },
                    { 8, 5, false, "Extend", 30, 1 },
                    { 5, 6, false, "Jett", 30, 1 }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Görele Terminal" },
                    { 4, 1, "Osmancık Terminal" },
                    { 2, 2, "Bolu Terminal" },
                    { 3, 3, "Gebze Terminal" },
                    { 5, 4, "Kaynarca Terminal" }
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusModelId", "DistanceTraveled", "RegistrationPlate", "SeatMapping", "Year" },
                values: new object[,]
                {
                    { 1, 1, 10000, "34 GMB 36", 2, (short)2011 },
                    { 3, 2, 10000, "34 ASL 422", 1, (short)1990 },
                    { 2, 3, 10000, "34 GDT 18", 3, (short)2012 },
                    { 4, 4, 10000, "34 EBG 28", 3, (short)1998 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_BusModelId",
                table: "Buses",
                column: "BusModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BusModels_BusManufacturerId",
                table: "BusModels",
                column: "BusManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CityId",
                table: "Stations",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "BusModels");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "BusManufacturers");
        }
    }
}
