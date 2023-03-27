using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelsinkiCityBikeApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FID = table.Column<int>(type: "INTEGER", nullable: false),
                    Nimi = table.Column<string>(type: "TEXT", nullable: true),
                    Namn = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Osoite = table.Column<string>(type: "TEXT", nullable: true),
                    Adress = table.Column<string>(type: "TEXT", nullable: true),
                    Kaupunki = table.Column<string>(type: "TEXT", nullable: true),
                    Stad = table.Column<string>(type: "TEXT", nullable: true),
                    Operaattor = table.Column<string>(type: "TEXT", nullable: true),
                    Kapasiteet = table.Column<int>(type: "INTEGER", nullable: true),
                    X = table.Column<double>(type: "REAL", nullable: false),
                    Y = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Departure = table.Column<string>(type: "TEXT", nullable: true),
                    Return = table.Column<string>(type: "TEXT", nullable: true),
                    DepartureStationId = table.Column<int>(type: "INTEGER", nullable: true),
                    DepartureStationName = table.Column<string>(type: "TEXT", nullable: true),
                    ReturnStationId = table.Column<int>(type: "INTEGER", nullable: true),
                    ReturnStationName = table.Column<string>(type: "TEXT", nullable: true),
                    CoveredDistance = table.Column<int>(type: "INTEGER", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
