using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Hand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseCompanyId",
                table: "CourseAIOrganizationalUnit",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAIOrganizationalUnit_CourseCompanyId",
                table: "CourseAIOrganizationalUnit",
                newName: "IX_CourseAIOrganizationalUnit_CourseId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "LastUpdate",
                table: "Course",
                type: "date",
                nullable: false,
                defaultValueSql: "(GETDATE())",
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<Guid>(
                name: "AcademicInstitutionId",
                table: "Course",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Course_AcademicInstitutionId",
                table: "Course",
                column: "AcademicInstitutionId");

            migrationBuilder.AddForeignKey(
                name: "AcademicInstitution_Course",
                table: "Course",
                column: "AcademicInstitutionId",
                principalTable: "AcademicInstitution",
                principalColumn: "AcademicInstitutionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "AcademicInstitution_Course",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_AcademicInstitutionId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "AcademicInstitutionId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseAIOrganizationalUnit",
                newName: "CourseCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAIOrganizationalUnit_CourseId",
                table: "CourseAIOrganizationalUnit",
                newName: "IX_CourseAIOrganizationalUnit_CourseCompanyId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "LastUpdate",
                table: "Course",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "(GETDATE())");
        }
    }
}
