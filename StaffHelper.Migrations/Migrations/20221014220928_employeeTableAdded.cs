using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffHelper.Migrations.Migrations
{
    public partial class employeeTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: false),
                    EmployeeIdentity = table.Column<string>(nullable: true),
                    OfficialMail = table.Column<string>(nullable: true),
                    OfficialPhoneNumber = table.Column<string>(nullable: true),
                    CompanyRoleId = table.Column<Guid>(nullable: false),
                    CompanyUnitId = table.Column<Guid>(nullable: false),
                    CompanyDesignationId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_CompanyDesignations_CompanyDesignationId",
                        column: x => x.CompanyDesignationId,
                        principalTable: "CompanyDesignations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_CompanyRoles_CompanyRoleId",
                        column: x => x.CompanyRoleId,
                        principalTable: "CompanyRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_CompanyUnits_CompanyUnitId",
                        column: x => x.CompanyUnitId,
                        principalTable: "CompanyUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyDesignationId",
                table: "Employees",
                column: "CompanyDesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyRoleId",
                table: "Employees",
                column: "CompanyRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyUnitId",
                table: "Employees",
                column: "CompanyUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
