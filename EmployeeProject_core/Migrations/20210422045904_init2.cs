using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeProject_core.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeToProjectViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    JoiningDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeToProjectViewModel");
        }
    }
}
