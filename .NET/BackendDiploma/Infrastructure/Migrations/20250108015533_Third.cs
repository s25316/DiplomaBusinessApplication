using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AISpecificType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AISpecificType_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AIStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AIStatus_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AIType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsSchool = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AIType_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicInstitution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LiquidationStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    liquidationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    WWW = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateOnly>(type: "date", nullable: false, defaultValueSql: "(GETDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("AcademicInstitution_pk", x => x.Id);
                    table.ForeignKey(
                        name: "AIType_AcademicInstitution",
                        column: x => x.TypeId,
                        principalTable: "AIType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "AcademicInstitution_AcademicInstitution",
                        column: x => x.ParentId,
                        principalTable: "AcademicInstitution",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AINameHistory",
                columns: table => new
                {
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AINameHistory_pk", x => new { x.InstitutionId, x.Date });
                    table.ForeignKey(
                        name: "AINameHistory_AcademicInstitution",
                        column: x => x.InstitutionId,
                        principalTable: "AcademicInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AISpecificTypeHistory",
                columns: table => new
                {
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AISpecificTypeHistory_pk", x => new { x.InstitutionId, x.TypeId, x.Date });
                    table.ForeignKey(
                        name: "AISpecificTypeHistory_AISpecificType",
                        column: x => x.TypeId,
                        principalTable: "AISpecificType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "AISpecificTypeHistory_AcademicInstitution",
                        column: x => x.InstitutionId,
                        principalTable: "AcademicInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIStatusHistory",
                columns: table => new
                {
                    InstitutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AIStatusHistory_pk", x => new { x.InstitutionId, x.StatusId, x.Date });
                    table.ForeignKey(
                        name: "AIStatusHistory_AIStatus",
                        column: x => x.StatusId,
                        principalTable: "AIStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "AIStatusHistory_AcademicInstitution",
                        column: x => x.InstitutionId,
                        principalTable: "AcademicInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInstitution_ParentId",
                table: "AcademicInstitution",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicInstitution_TypeId",
                table: "AcademicInstitution",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AISpecificTypeHistory_TypeId",
                table: "AISpecificTypeHistory",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AIStatusHistory_StatusId",
                table: "AIStatusHistory",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AINameHistory");

            migrationBuilder.DropTable(
                name: "AISpecificTypeHistory");

            migrationBuilder.DropTable(
                name: "AIStatusHistory");

            migrationBuilder.DropTable(
                name: "AISpecificType");

            migrationBuilder.DropTable(
                name: "AIStatus");

            migrationBuilder.DropTable(
                name: "AcademicInstitution");

            migrationBuilder.DropTable(
                name: "AIType");
        }
    }
}
