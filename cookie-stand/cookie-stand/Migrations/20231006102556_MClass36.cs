using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cookie_stand.Migrations
{
    /// <inheritdoc />
    public partial class MClass36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CookieStands",
                columns: table => new
                {
                    CookieStandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Minimum_customers_per_hour = table.Column<int>(type: "int", nullable: false),
                    Maximum_customers_per_hour = table.Column<int>(type: "int", nullable: false),
                    Average_cookies_per_sale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookieStands", x => x.CookieStandId);
                });

            migrationBuilder.CreateTable(
                name: "HourlySales",
                columns: table => new
                {
                    HourlySaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourlySales", x => x.HourlySaleId);
                });

            migrationBuilder.CreateTable(
                name: "CookiStandHourlySales",
                columns: table => new
                {
                    HourlySaleId = table.Column<int>(type: "int", nullable: false),
                    CookieStandId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookiStandHourlySales", x => new { x.HourlySaleId, x.CookieStandId });
                    table.ForeignKey(
                        name: "FK_CookiStandHourlySales_CookieStands_CookieStandId",
                        column: x => x.CookieStandId,
                        principalTable: "CookieStands",
                        principalColumn: "CookieStandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookiStandHourlySales_HourlySales_HourlySaleId",
                        column: x => x.HourlySaleId,
                        principalTable: "HourlySales",
                        principalColumn: "HourlySaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HourlySales",
                columns: new[] { "HourlySaleId", "Time" },
                values: new object[,]
                {
                    { 1, 6 },
                    { 2, 7 },
                    { 3, 8 },
                    { 4, 9 },
                    { 5, 10 },
                    { 6, 11 },
                    { 7, 12 },
                    { 8, 1 },
                    { 9, 2 },
                    { 10, 3 },
                    { 11, 4 },
                    { 12, 5 },
                    { 13, 6 },
                    { 14, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookiStandHourlySales_CookieStandId",
                table: "CookiStandHourlySales",
                column: "CookieStandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookiStandHourlySales");

            migrationBuilder.DropTable(
                name: "CookieStands");

            migrationBuilder.DropTable(
                name: "HourlySales");
        }
    }
}
