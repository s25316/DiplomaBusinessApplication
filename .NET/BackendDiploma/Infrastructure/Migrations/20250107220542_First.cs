using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Country_pk", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "DivisionType",
                columns: table => new
                {
                    DivisionTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("DivisionType_pk", x => x.DivisionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    ParentDivisionId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DivisionTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ParentsPath = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Division_pk", x => x.DivisionId);
                    table.ForeignKey(
                        name: "Country_Division",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "DivisionType_Division",
                        column: x => x.DivisionTypeId,
                        principalTable: "DivisionType",
                        principalColumn: "DivisionTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Division_Division",
                        column: x => x.ParentDivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId");
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    DivisionTypeId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Street_pk", x => x.StreetId);
                    table.ForeignKey(
                        name: "Country_Street",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "DivisionType_Street",
                        column: x => x.DivisionTypeId,
                        principalTable: "DivisionType",
                        principalColumn: "DivisionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StreetId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Address_pk", x => x.AddressId);
                    table.ForeignKey(
                        name: "Address_Division",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Address_Street",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DivisionStreet",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    StreetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionStreet", x => new { x.DivisionId, x.StreetId });
                    table.ForeignKey(
                        name: "FK_DivisionStreet_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivisionStreet_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_DivisionId",
                table: "Address",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetId",
                table: "Address",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_CountryId",
                table: "Division",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_DivisionTypeId",
                table: "Division",
                column: "DivisionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_ParentDivisionId",
                table: "Division",
                column: "ParentDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DivisionStreet_StreetId",
                table: "DivisionStreet",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_CountryId",
                table: "Street",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_DivisionTypeId",
                table: "Street",
                column: "DivisionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DivisionStreet");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "DivisionType");
        }
    }
}
