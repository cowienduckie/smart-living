using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartLiving.Data.Migrations
{
    public partial class UpdateDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "DeviceType");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "TimeActivated",
                schema: "dbo",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "TimeDeactivated",
                schema: "dbo",
                table: "Device");

            migrationBuilder.AddColumn<string>(
                name: "DefaultParams",
                schema: "dbo",
                table: "DeviceType",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleId1",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityRole<string>",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<string>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<string>",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId1",
                table: "UserRoles",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId1",
                table: "UserRoles",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId1",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "IdentityRole<string>");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<string>");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_RoleId1",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DefaultParams",
                schema: "dbo",
                table: "DeviceType");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "UserRoles");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "DeviceType",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "dbo",
                table: "Device",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeActivated",
                schema: "dbo",
                table: "Device",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeDeactivated",
                schema: "dbo",
                table: "Device",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}