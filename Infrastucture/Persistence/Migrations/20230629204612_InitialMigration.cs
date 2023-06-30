using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastucture.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Sku = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    TravelDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Price_Currency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false),
                    Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserves_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LineDestinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    PackageId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Price_Currency = table.Column<string>(type: "longtext", nullable: false),
                    Price_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReserveId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineDestinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineDestinations_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineDestinations_Reserves_ReserveId",
                        column: x => x.ReserveId,
                        principalTable: "Reserves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineDestinations_PackageId",
                table: "LineDestinations",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_LineDestinations_ReserveId",
                table: "LineDestinations",
                column: "ReserveId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_CustomerId",
                table: "Reserves",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineDestinations");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
