using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StaffHelper.Migrations.Migrations
{
    public partial class companyUnitTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyDesignations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDesignations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyDesignations_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyUnits_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyDesignations_CompanyId",
                table: "CompanyDesignations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUnits_CompanyId",
                table: "CompanyUnits",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDesignations");

            migrationBuilder.DropTable(
                name: "CompanyUnits");
        }
    }
}
