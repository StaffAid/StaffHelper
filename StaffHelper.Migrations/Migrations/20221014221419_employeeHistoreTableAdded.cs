using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffHelper.Migrations.Migrations
{
    public partial class employeeHistoreTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmploymentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    EmployeeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentHistories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmploymentHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmploymentHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_CompanyId",
                table: "EmploymentHistories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_EmployeeId",
                table: "EmploymentHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistories_UserId",
                table: "EmploymentHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmploymentHistories");
        }
    }
}
