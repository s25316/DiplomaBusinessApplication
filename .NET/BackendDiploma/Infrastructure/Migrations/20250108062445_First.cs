using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AIOrganizationalUnit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AIOrganizationalUnit_pk", x => x.Id);
                });

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
                name: "CourseForm",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CourseForm_pk", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevel",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CourseLevel_pk", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CourseProfile",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CourseProfile_pk", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CourseTitle",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CourseTitle_pk", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Discipline_pk", x => x.Code);
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
                name: "Isced",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Isced_pk", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Language_pk", x => x.Code);
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
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumberOfSemesters = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LiquidationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FormCode = table.Column<int>(type: "int", nullable: true),
                    TitleCode = table.Column<int>(type: "int", nullable: true),
                    LevelCode = table.Column<int>(type: "int", nullable: true),
                    ProfileCode = table.Column<int>(type: "int", nullable: true),
                    LanguageCode = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    IscedCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Course_pk", x => x.Id);
                    table.ForeignKey(
                        name: "Course_CourseForm",
                        column: x => x.FormCode,
                        principalTable: "CourseForm",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Course_CourseLevel",
                        column: x => x.LevelCode,
                        principalTable: "CourseLevel",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Course_CourseProfile",
                        column: x => x.ProfileCode,
                        principalTable: "CourseProfile",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Course_CourseTitle",
                        column: x => x.TitleCode,
                        principalTable: "CourseTitle",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Course_Isced",
                        column: x => x.IscedCode,
                        principalTable: "Isced",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Course_Language",
                        column: x => x.LanguageCode,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "CourseAIOrganizationalUnit",
                columns: table => new
                {
                    AIOrganizationalUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAIOrganizationalUnit", x => new { x.AIOrganizationalUnitId, x.CourseId });
                    table.ForeignKey(
                        name: "CourseAIOrganizationalUnit_AIOrganizationalUnit",
                        column: x => x.AIOrganizationalUnitId,
                        principalTable: "AIOrganizationalUnit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "CourseAIOrganizationalUnit_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDiscipline",
                columns: table => new
                {
                    DisciplineCode = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PercentageShare = table.Column<int>(type: "int", nullable: true),
                    DisciplineLeading = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CourseDiscipline_pk", x => new { x.DisciplineCode, x.CourseId });
                    table.ForeignKey(
                        name: "CourseDiscipline_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CourseDiscipline_Discipline",
                        column: x => x.DisciplineCode,
                        principalTable: "Discipline",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseLanguage",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLanguage", x => new { x.CourseId, x.LanguageId });
                    table.ForeignKey(
                        name: "CourseLanguage_Course",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "CourseLanguage_Language",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseForm",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { 1, "stacjonarne" },
                    { 2, "niestacjonarne" }
                });

            migrationBuilder.InsertData(
                table: "CourseLevel",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { 1, "jednolite magisterskie" },
                    { 2, "pierwszego stopnia" },
                    { 3, "drugiego stopnia" }
                });

            migrationBuilder.InsertData(
                table: "CourseProfile",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { 1, "praktyczny" },
                    { 2, "ogólnoakademicki" }
                });

            migrationBuilder.InsertData(
                table: "CourseTitle",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { 1, "magister" },
                    { 2, "licencjat" },
                    { 3, "inżynier" },
                    { 4, "magister inżynier" }
                });

            migrationBuilder.InsertData(
                table: "Discipline",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "DS010101N", "archeologia" },
                    { "DS010102N", "filozofia" },
                    { "DS010103N", "historia" },
                    { "DS010104N", "językoznawstwo" },
                    { "DS010105N", "literaturoznawstwo" },
                    { "DS010106N", "nauki o kulturze i religii" },
                    { "DS010107N", "nauki o sztuce" },
                    { "DS010108N", "etnologia i antropologia kulturowa" },
                    { "DS010109N", "polonistyka" },
                    { "DS010201N", "architektura i urbanistyka" },
                    { "DS010202N", "inżynieria biomedyczna" },
                    { "DS010204N", "informatyka techniczna i telekomunikacja" },
                    { "DS010205N", "inżynieria chemiczna" },
                    { "DS010207N", "inżynieria materiałowa" },
                    { "DS010208N", "inżynieria mechaniczna" },
                    { "DS010209N", "inżynieria środowiska, górnictwo i energetyka" },
                    { "DS010210N", "inżynieria bezpieczeństwa" },
                    { "DS010211N", "ochrona dziedzictwa i konserwacja zabytków" },
                    { "DS010212N", "inżynieria lądowa, geodezja i transport" },
                    { "DS010213N", "automatyka, elektronika, elektrotechnika i technologie kosmiczne" },
                    { "DS010301N", "nauki farmaceutyczne" },
                    { "DS010302N", "nauki o kulturze fizycznej" },
                    { "DS010303N", "nauki o zdrowiu" },
                    { "DS010304N", "nauki medyczne" },
                    { "DS010305N", "biologia medyczna" },
                    { "DS010401N", "rolnictwo i ogrodnictwo" },
                    { "DS010402N", "technologia żywności i żywienia" },
                    { "DS010404N", "zootechnika i rybactwo" },
                    { "DS010405N", "nauki leśne" },
                    { "DS010501N", "ekonomia i finanse" },
                    { "DS010502N", "geografia społeczno-ekonomiczna i gospodarka przestrzenna" },
                    { "DS010503N", "nauki o bezpieczeństwie" },
                    { "DS010504N", "nauki o komunikacji społecznej i mediach" },
                    { "DS010505N", "nauki o polityce i administracji" },
                    { "DS010506N", "nauki o zarządzaniu i jakości" },
                    { "DS010507N", "nauki prawne" },
                    { "DS010508N", "nauki socjologiczne" },
                    { "DS010509N", "pedagogika" },
                    { "DS010510N", "prawo kanoniczne" },
                    { "DS010511N", "psychologia" },
                    { "DS010512N", "stosunki międzynarodowe" },
                    { "DS010601N", "informatyka" },
                    { "DS010602N", "matematyka" },
                    { "DS010603N", "nauki biologiczne" },
                    { "DS010604N", "nauki chemiczne" },
                    { "DS010605N", "nauki fizyczne" },
                    { "DS010606N", "nauki o Ziemi i środowisku" },
                    { "DS010607N", "astronomia" },
                    { "DS010608N", "biotechnologia" },
                    { "DS010701N", "nauki teologiczne" },
                    { "DS010702N", "nauki biblijne" },
                    { "DS010801N", "sztuki filmowe i teatralne" },
                    { "DS010802N", "sztuki muzyczne" },
                    { "DS010803N", "sztuki plastyczne i konserwacja dzieł sztuki" },
                    { "DS010901N", "nauki o rodzinie" },
                    { "DS011001N", "weterynaria" }
                });

            migrationBuilder.InsertData(
                table: "Isced",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "00", "Grupa Programy ogólne" },
                    { "000", "Podgrupa programów i kwalifikacji ogólnych nieokreślonych dalej" },
                    { "0000", "Programy i kwalifikacje ogólne nieokreślone dalej" },
                    { "001", "Podgrupa programów i kwalifikacji podstawowych" },
                    { "0011", "Podstawowe programy i kwalifikacje" },
                    { "002", "Podgrupa umiejętności czytania, pisania i liczenia" },
                    { "0021", "Umiejętność czytania, pisania i liczenia" },
                    { "003", "Podgrupa rozwoju umiejętności osobowościowych" },
                    { "0031", "Rozwój umiejętności osobowościowych" },
                    { "009", "Podgrupa programów i kwalifikacji ogólnych gdzie indziej niesklasyfikowanych" },
                    { "0099", "Programy i kwalifikacje ogólne, gdzie indziej niesklasyfikowane" },
                    { "01", "Grupa Kształcenie" },
                    { "011", "Podgrupa pedagogiczna" },
                    { "0110", "Kształcenie nieokreślone dalej" },
                    { "0111", "Kształcenie" },
                    { "0112", "Kształcenie nauczycieli nauczania przedszkolnego" },
                    { "0113", "Kształcenie nauczycieli bez specjalizacji tematycznej" },
                    { "0114", "Kształcenie nauczycieli ze specjalizacją tematyczną" },
                    { "0119", "Kształcenie gdzie indziej niesklasyfikowane" },
                    { "018", "Podgrupa interdyscyplinarnych programów i kwalifikacji związanych z edukacją" },
                    { "0188", "Interdyscyplinarne programy i kwalifikacje związane z edukacją" },
                    { "02", "Grupa Nauki humanistyczne i sztuka" },
                    { "020", "Podgrupa programów i kwalifikacji związanych ze sztuką i przedmiotami humanistycznymi nieokreślonymi dalej" },
                    { "0200", "Programy i kwalifikacje związane ze sztuką i przedmiotami humanistycznymi nieokreślone dalej" },
                    { "021", "Podgrupa artystyczna" },
                    { "0210", "Programy i kwalifikacje związane ze sztuką nieokreślone dalej" },
                    { "0211", "Techniki audiowizualne i produkcja mediów" },
                    { "0212", "Moda, wystrój wnętrz i projektowanie przemysłowe" },
                    { "0213", "Sztuki plastyczne" },
                    { "0214", "Rękodzieło" },
                    { "0215", "Muzyka i sztuki sceniczne" },
                    { "0219", "Programy i kwalifikacje związane ze sztuką gdzie indziej niesklasyfikowane" },
                    { "022", "Podgrupa humanistyczna (z wyłączeniem języków)" },
                    { "0220", "Przedmioty humanistyczne (z wyłączeniem języków) nie określone dalej" },
                    { "0221", "Religia i teologia" },
                    { "0222", "Historia i archeologia" },
                    { "0223", "Filozofia i etyka" },
                    { "0229", "Przedmioty humanistyczne (z wyłączeniem języków) gdzie indziej niesklasyfikowane" },
                    { "023", "Podgrupa językowa" },
                    { "0230", "Języki nie określone dalej" },
                    { "0231", "Nauka języków" },
                    { "0232", "Literatura i językoznawstwo (lingwistyka)" },
                    { "0239", "Programy i kwalifikacje związane z językami gdzie indziej niesklasyfikowane" },
                    { "028", "Podgrupa interdyscyplinarnych programów i kwalifikacji związanych ze sztuką i przedmiotami humanistycznymi" },
                    { "0288", "Interdyscyplinarne programy i kwalifikacje obejmujące sztuki i przedmioty humanistyczne" },
                    { "029", "Podgrupa programów i kwalifikacji związanych ze sztuką i przedmiotami humanistycznymi gdzie indziej niesklasyfikowanymi" },
                    { "0299", "Programy i kwalifikacje związane ze sztuką i przedmiotami humanistycznymi gdzie indziej niesklasyfikowane" },
                    { "03", "Grupa Nauki społeczne, dziennikarstwo i informacja" },
                    { "030", "Podgrupa nauk społecznych, dziennikarstwa i informacji nieokreślonych dalej" },
                    { "0300", "Nauki społeczne, dziennikarstwo i informacja nieokreślone dalej" },
                    { "031", "Podgrupa społeczna" },
                    { "0310", "Nauki społeczne nieokreślone dalej" },
                    { "0311", "Ekonomia" },
                    { "0312", "Politologia i wiedza o społeczeństwie" },
                    { "0313", "Psychologia" },
                    { "0314", "Socjologia i kulturoznawstwo" },
                    { "0319", "Programy i kwalifikacje związane z naukami społecznymi, gdzie indziej niesklasyfikowane" },
                    { "032", "Podgrupa dziennikarstwa i informacji" },
                    { "0320", "Dziennikarstwo i informacja naukowa nieokreślone dalej" },
                    { "0321", "Dziennikarstwo" },
                    { "0322", "Bibliotekoznawstwo, informacja naukowa i archiwistyka" },
                    { "0329", "Dziennikarstwo i informacja naukowa gdzie indziej niesklasyfikowane" },
                    { "038", "Podgrupa interdyscyplinarnych programów i kwalifikacji związanych z naukami społecznymi, dziennikarstwem i informacją" },
                    { "0388", "Interdyscyplinarne programy i kwalifikacje związane z naukami społecznymi, dziennikarstwem i informacją" },
                    { "039", "Podgrupa nauk społecznych, dziennikarstwa i informacji gdzie indziej niesklasyfikowanych" },
                    { "0399", "Nauki społeczne, dziennikarstwo i informacja gdzie indziej niesklasyfikowane" },
                    { "04", "Grupa Biznes, administracja i prawo" },
                    { "040", "Podgrupa biznesu, administracji i prawa nieokreślonych dalej" },
                    { "0400", "Biznes, administracja i prawo nieokreślone dalej" },
                    { "041", "Podgrupa biznesu i administracji" },
                    { "0410", "Biznes i administracja nie określone dalej" },
                    { "0411", "Rachunkowość i podatki" },
                    { "0412", "Finanse, bankowość i ubezpieczenia" },
                    { "0413", "Zarządzanie i administracja" },
                    { "0414", "Marketing i reklama" },
                    { "0415", "Prace sekretarskie i biurowe" },
                    { "0416", "Sprzedaż hurtowa i detaliczna" },
                    { "0417", "Umiejętności związane z miejscem pracy" },
                    { "0419", "Programy i kwalifikacje związane z prowadzeniem działalności gospodarczej i administracją gdzie indziej niesklasyfikowane" },
                    { "042", "Podgrupa prawna" },
                    { "0421", "Prawo" },
                    { "048", "Podgrupa interdyscyplinarnych programów i kwalifikacji związanych z prowadzeniem działalności gospodarczej, administracją i prawem" },
                    { "0488", "Interdyscyplinarne programy i kwalifikacje związane z prowadzeniem działalności gospodarczej, administracją i prawem" },
                    { "049", "Podgrupa programów i kwalifikacji związanych z prowadzeniem działalności gospodarczej, administracją i prawem gdzie indziej niesklasyfikowanych" },
                    { "0499", "Programy i kwalifikacje obejmujące prowadzenie działalności gospodarczej, administrację i prawo gdzie indziej niesklasyfikowane" },
                    { "05", "Grupa Nauki przyrodnicze, matematyka i statystyka" },
                    { "050", "Podgrupa nauk przyrodniczych, matematyki i statystyki nieokreślonych dalej" },
                    { "0500", "Nauki przyrodnicze, matematyka i statystyka nieokreślone dalej" },
                    { "051", "Podgrupa biologiczna" },
                    { "0510", "Nauki biologiczne i powiązane nieokreślone dalej" },
                    { "0511", "Biologia" },
                    { "0512", "Biochemia" },
                    { "0519", "Programy i kwalifikacje związane z biologią i naukami pokrewnymi gdzie indziej niesklasyfikowane" },
                    { "052", "Podgrupa nauk o środowisku" },
                    { "0520", "Nauki o środowisku nieokreślone dalej" },
                    { "0521", "Ekologia i ochrona środowiska" },
                    { "0522", "Środowisko naturalne i przyroda" },
                    { "0529", "Programy i kwalifikacje związane ze środowiskiem gdzie indziej niesklasyfikowane" },
                    { "053", "Podgrupa fizyczna" },
                    { "0530", "Nauki fizyczne nieokreślone dalej" },
                    { "0531", "Chemia" },
                    { "0532", "Nauki o Ziemi" },
                    { "0533", "Fizyka" },
                    { "0539", "Programy i kwalifikacje związane z naukami fizycznymi gdzie indziej niesklasyfikowane" },
                    { "054", "Podgrupa matematyczna i statystyczna" },
                    { "0540", "Matematyka i statystyka nieokreślone dalej" },
                    { "0541", "Matematyka" },
                    { "0542", "Statystyka" },
                    { "058", "Podgrupa interdyscyplinarnych programów i kwalifikacji obejmujących nauki przyrodnicze, matematykę i statystykę" },
                    { "0588", "Interdyscyplinarne programy i kwalifikacje obejmujące nauki przyrodnicze, matematykę i statystykę" },
                    { "059", "Podgrupa nauk przyrodniczych, matematyki i statystyki gdzie indziej niesklasyfikowanych" },
                    { "0599", "Nauki przyrodnicze, matematyka i statystyka gdzie indziej niesklasyfikowane" },
                    { "06", "Grupa Technologie teleinformacyjne" },
                    { "061", "Podgrupa technologii teleinformacyjnych" },
                    { "0610", "Technologie teleinformacyjne nieokreślone dalej" },
                    { "0611", "Obsługa i użytkowanie komputerów" },
                    { "0612", "Projektowanie i administrowanie baz danych i sieci" },
                    { "0613", "Tworzenie i analiza oprogramowania i aplikacji" },
                    { "0619", "Technologie teleinformacyjne gdzie indziej niesklasyfikowane" },
                    { "068", "Podgrupa interdyscyplinarnych programów i kwalifikacji obejmujących technologie informacyjno-komunikacyjne" },
                    { "0688", "Interdyscyplinarne programy i kwalifikacje obejmujące technologie informacyjno-komunikacyjne" },
                    { "07", "Grupa Technika, przemysł, budownictwo" },
                    { "070", "Podgrupa techniki, przemysłu i budownictwa nieokreślonych dalej" },
                    { "0700", "Technika, przemysł i budownictwo nieokreślone dalej" },
                    { "071", "Podgrupa inżynieryjno-techniczna" },
                    { "0710", "Inżynieria i zawody inżynieryjne nieokreślone dalej" },
                    { "0711", "Inżynieria chemiczna i procesowa" },
                    { "0712", "Technologie związane z ochroną środowiska" },
                    { "0713", "Elektryczność i energia" },
                    { "0714", "Elektronika i automatyka" },
                    { "0715", "Mechanika i metalurgia" },
                    { "0716", "Pojazdy samochodowe, statki i samoloty" },
                    { "0719", "Inżynieria i zawody inżynierskie gdzie indziej niesklasyfikowane" },
                    { "072", "Podgrupa produkcji i przetwórstwa" },
                    { "0720", "Produkcja i przetwórstwo nieokreślone dalej" },
                    { "0721", "Przetwórstwo żywności" },
                    { "0722", "Surowce (szkło, papier, tworzywo sztuczne i drewno)" },
                    { "0723", "Tekstylia (odzież, obuwie i wyroby skórzane)" },
                    { "0724", "Górnictwo i wydobycie" },
                    { "0729", "Programy i kwalifikacje związane z przetwórstwem przemysłowym gdzie indziej niesklasyfikowane" },
                    { "073", "Podgrupa architektury i budownictwa" },
                    { "0730", "Architektura i budownictwo nieokreślone dalej" },
                    { "0731", "Architektura i planowanie przestrzenne" },
                    { "0732", "Budownictwo i inżynieria lądowa i wodna" },
                    { "078", "Podgrupa interdyscyplinarnych programów i kwalifikacji obejmujących technikę, przemysł i budownictwo" },
                    { "0788", "Interdyscyplinarne programy i kwalifikacje obejmujące technikę, przemysł i budownictwo" },
                    { "079", "Podgrupa techniki, przemysłu i budownictwa gdzie indziej niesklasyfikowanych" },
                    { "0799", "Technika, przemysł i budownictwo gdzie indziej niesklasyfikowane" },
                    { "08", "Grupa Rolnictwo" },
                    { "080", "Rolnictwo, leśnictwo, rybołówstwo i weterynaria nieokreślone dalej" },
                    { "0800", "Rolnictwo, leśnictwo, rybołówstwo i weterynaria nieokreślone dalej" },
                    { "081", "Podgrupa rolnicza" },
                    { "0810", "Rolnictwo nieokreślone dalej" },
                    { "0811", "Produkcja roślinna i zwierzęca" },
                    { "0812", "Ogrodnictwo" },
                    { "0819", "Programy i kwalifikacje związane z rolnictwem gdzie indziej niesklasyfikowane" },
                    { "082", "Podgrupa leśna" },
                    { "0821", "Leśnictwo" },
                    { "083", "Podgrupa rybactwa" },
                    { "0831", "Rybactwo" },
                    { "084", "Podgrupa weterynaryjna" },
                    { "0841", "Weterynaria" },
                    { "088", "Podgrupa interdyscyplinarnych programów i kwalifikacji obejmujących rolnictwo, leśnictwo, rybactwo i weterynarię" },
                    { "0888", "Interdyscyplinarne programy i kwalifikacje obejmujące rolnictwo, leśnictwo, rybactwo i weterynarię" },
                    { "089", "Podgrupa rolnictwa, leśnictwa, rybactwa i weterynaria gdzie indziej niesklasyfikowanych" },
                    { "0899", "Rolnictwo, leśnictwo, rybactwo i weterynaria gdzie indziej niesklasyfikowane" },
                    { "09", "Grupa Zdrowie i opieka społeczna" },
                    { "090", "Podgrupa zdrowia i opieki społecznej nieokreślonych dalej" },
                    { "0900", "Zdrowie i opieka społeczna nieokreślone dalej" },
                    { "091", "Podgrupa medyczna" },
                    { "0910", "Zdrowie nieokreślone dalej" },
                    { "0911", "Stomatologia" },
                    { "0912", "Medycyna" },
                    { "0913", "Pielęgniarstwo i położnictwo" },
                    { "0914", "Technologie związane z diagnostyką i leczeniem" },
                    { "0915", "Terapia i rehabilitacja" },
                    { "0916", "Farmacja" },
                    { "0917", "Medycyna i terapia tradycyjna oraz komplementarna" },
                    { "0919", "Zdrowie gdzie indziej niesklasyfikowane" },
                    { "092", "Podgrupa opieki społecznej" },
                    { "0920", "Opieka społeczna nieokreślona dalej" },
                    { "0921", "Opieka nad osobami starszymi i dorosłymi niepełnosprawnymi" },
                    { "0922", "Usługi związane z opieką nad dziećmi i młodzieżą" },
                    { "0923", "Praca socjalna i doradztwo" },
                    { "0929", "Opieka społeczna gdzie indziej niesklasyfikowana" },
                    { "098", "Podgrupa interdyscyplinarnych programów i kwalifikacji obejmujących zdrowie i opiekę społeczną" },
                    { "0988", "Interdyscyplinarne programy i kwalifikacje obejmujące zdrowie i opiekę społeczną" },
                    { "099", "Podgrupa zdrowie i opieka społeczna gdzie indziej niesklasyfikowane" },
                    { "0999", "Zdrowie i opieka społeczna gdzie indziej niesklasyfikowane" },
                    { "10", "Grupa Usługi" },
                    { "100", "Podgrupa usług nieokreślonych dalej" },
                    { "1000", "Usługi nieokreślone dalej" },
                    { "101", "Podgrupa usług dla ludności" },
                    { "1010", "Usługi dla ludności nieokreślone dalej" },
                    { "1011", "Usługi domowe" },
                    { "1012", "Pielęgnacja włosów i urody" },
                    { "1013", "Hotele, restauracje i katering" },
                    { "1014", "Sport" },
                    { "1015", "Turystyka i wypoczynek" },
                    { "1019", "Programy i kwalifikacje związane z usługi dla ludności gdzie indziej niesklasyfikowane" },
                    { "102", "Podgrupa higieny i bezpieczeństwa pracy" },
                    { "1020", "Usługi higieny i bezpieczeństwa pracy nieokreślone dalej" },
                    { "1021", "Higiena publiczna" },
                    { "1022", "Bezpieczeństwo i higiena pracy" },
                    { "1029", "Programy i kwalifikacje związane z usługami w zakresie higieny i bezpieczeństwa pracy" },
                    { "103", "Podgrupa ochrony i bezpieczeństwa" },
                    { "1030", "Ochrona i bezpieczeństwo nieokreślone dalej" },
                    { "1031", "Wojsko i obronność" },
                    { "1032", "Ochrona osób i mienia" },
                    { "1039", "Programy i kwalifikacje związane z ochroną i bezpieczeństwem gdzie indziej niesklasyfikowane" },
                    { "104", "Podgrupa usług transportowych" },
                    { "1041", "Transport" },
                    { "108", "Podgrupa interdyscyplinarnych programów i kwalifikacji obejmujących usługi" },
                    { "1088", "Interdyscyplinarne programy i kwalifikacje obejmujące usługi" },
                    { "109", "Podgrupa usług gdzie indziej niesklasyfikowanych" },
                    { "1099", "Usługi gdzie indziej niesklasyfikowane" },
                    { "99", "Grupa Obszar nieznany" },
                    { "999", "Podgrupa obszar nieznany" },
                    { "9999", "Obszar nieznany" }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "alb-sqi", "albański" },
                    { "ara", "arabski" },
                    { "bel", "białoruski" },
                    { "bul", "bułgarski" },
                    { "cat", "kataloński" },
                    { "cel", "celtyckie" },
                    { "chi-zho", "chiński" },
                    { "cze-ces", "czeski" },
                    { "dan", "duński" },
                    { "dut-nld", "holenderski" },
                    { "eng", "angielski" },
                    { "fin", "fiński" },
                    { "fre-fra", "francuski" },
                    { "gem", "germańskie" },
                    { "ger-deu", "niemiecki" },
                    { "gre-ell", "grecki" },
                    { "heb", "hebrajski" },
                    { "hin", "hindi" },
                    { "hun", "węgierski" },
                    { "ice-isl", "islandzki" },
                    { "ind", "indonezyjski" },
                    { "ita", "włoski" },
                    { "jpn", "japoński" },
                    { "kor", "koreański" },
                    { "lat", "łacina" },
                    { "lav", "łotewski" },
                    { "lit", "litewski" },
                    { "mac-mkd", "macedoński" },
                    { "may-msa", "malajski" },
                    { "nno", "neonorweski (nynorsk)" },
                    { "nob", "norweski tradycyjny (bokmal)" },
                    { "nor", "norweski" },
                    { "opi-ij", "inny język" },
                    { "per-fas", "perski (farsi)" },
                    { "pol", "polski" },
                    { "por", "portugalski" },
                    { "pso", "polski język migowy" },
                    { "rum-ron", "rumuński" },
                    { "rus", "rosyjski" },
                    { "scc-srp", "serbski" },
                    { "scr-hrv", "chorwacki" },
                    { "slo-slk", "słowacki" },
                    { "slv", "słoweński" },
                    { "spa", "hiszpański" },
                    { "swe", "szwedzki" },
                    { "tur", "turecki" },
                    { "ukr", "ukraiński" },
                    { "urd", "urdu" },
                    { "vie", "wietnamski" },
                    { "yid", "jidysz" }
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
                name: "IX_Address_DivisionId",
                table: "Address",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetId",
                table: "Address",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_AISpecificTypeHistory_TypeId",
                table: "AISpecificTypeHistory",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AIStatusHistory_StatusId",
                table: "AIStatusHistory",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_FormCode",
                table: "Course",
                column: "FormCode");

            migrationBuilder.CreateIndex(
                name: "IX_Course_IscedCode",
                table: "Course",
                column: "IscedCode");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LanguageCode",
                table: "Course",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LevelCode",
                table: "Course",
                column: "LevelCode");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ProfileCode",
                table: "Course",
                column: "ProfileCode");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TitleCode",
                table: "Course",
                column: "TitleCode");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAIOrganizationalUnit_CourseId",
                table: "CourseAIOrganizationalUnit",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDiscipline_CourseId",
                table: "CourseDiscipline",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLanguage_LanguageId",
                table: "CourseLanguage",
                column: "LanguageId");

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
                name: "AINameHistory");

            migrationBuilder.DropTable(
                name: "AISpecificTypeHistory");

            migrationBuilder.DropTable(
                name: "AIStatusHistory");

            migrationBuilder.DropTable(
                name: "CourseAIOrganizationalUnit");

            migrationBuilder.DropTable(
                name: "CourseDiscipline");

            migrationBuilder.DropTable(
                name: "CourseLanguage");

            migrationBuilder.DropTable(
                name: "DivisionStreet");

            migrationBuilder.DropTable(
                name: "AISpecificType");

            migrationBuilder.DropTable(
                name: "AIStatus");

            migrationBuilder.DropTable(
                name: "AcademicInstitution");

            migrationBuilder.DropTable(
                name: "AIOrganizationalUnit");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "AIType");

            migrationBuilder.DropTable(
                name: "CourseForm");

            migrationBuilder.DropTable(
                name: "CourseLevel");

            migrationBuilder.DropTable(
                name: "CourseProfile");

            migrationBuilder.DropTable(
                name: "CourseTitle");

            migrationBuilder.DropTable(
                name: "Isced");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "DivisionType");
        }
    }
}
