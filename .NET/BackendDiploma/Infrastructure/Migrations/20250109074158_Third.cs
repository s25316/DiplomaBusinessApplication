using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "CompanyStatusHistory_pk",
                table: "CompanyStatusHistory");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "WWW",
                table: "Company");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "CompanyStatusHistory_pk",
                table: "CompanyStatusHistory",
                columns: new[] { "CompanyId", "Date", "StatusId" });

            migrationBuilder.CreateTable(
                name: "CompanyClassification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyClassification_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Country_CompanyClassification",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyIdentifier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyIdentifier_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Country_CompanyIdentifier",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyClassificationDetail",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassificationId = table.Column<int>(type: "int", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyClassificationDetail_pk", x => new { x.CompanyId, x.ClassificationId });
                    table.ForeignKey(
                        name: "CompanyClassificationDetail_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CompanyClassificationDetail_CompanyClassification",
                        column: x => x.ClassificationId,
                        principalTable: "CompanyClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyIdentifierDetail",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CompanyIdentifierDetail_pk", x => new { x.CompanyId, x.IdentifierId });
                    table.ForeignKey(
                        name: "CompanyIdentifierDetail_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CompanyIdentifierDetail_CompanyIdentifier",
                        column: x => x.IdentifierId,
                        principalTable: "CompanyIdentifier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CompanyStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Działająca" },
                    { 2, "W likwidacji" },
                    { 3, "Zlikwidowana" },
                    { 4, "Przekształcona" },
                    { 8, "Wykreślona z wykazu" },
                    { 11, "Zawieszona" },
                    { 12, "Wznowiona" },
                    { 13, "Zakończona" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Name" },
                values: new object[] { 1, "Polska" });

            migrationBuilder.InsertData(
                table: "CompanyIdentifier",
                columns: new[] { "Id", "CountryId", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, 1, "Numer identyfikacji podatkowej", "NIP" },
                    { 2, 1, "Krajowy Rejestr Urzędowy Podmiotów Gospodarki Narodowej", "REGON" },
                    { 3, 1, "Krajowy Rejestr Sądowy", "KRS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClassification_CountryId",
                table: "CompanyClassification",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyClassificationDetail_ClassificationId",
                table: "CompanyClassificationDetail",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIdentifier_CountryId",
                table: "CompanyIdentifier",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyIdentifierDetail_IdentifierId",
                table: "CompanyIdentifierDetail",
                column: "IdentifierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyClassificationDetail");

            migrationBuilder.DropTable(
                name: "CompanyIdentifierDetail");

            migrationBuilder.DropTable(
                name: "CompanyClassification");

            migrationBuilder.DropTable(
                name: "CompanyIdentifier");

            migrationBuilder.DropPrimaryKey(
                name: "CompanyStatusHistory_pk",
                table: "CompanyStatusHistory");

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CompanyStatus",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WWW",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "CompanyStatusHistory_pk",
                table: "CompanyStatusHistory",
                columns: new[] { "CompanyId", "Date" });
        }
    }
}
