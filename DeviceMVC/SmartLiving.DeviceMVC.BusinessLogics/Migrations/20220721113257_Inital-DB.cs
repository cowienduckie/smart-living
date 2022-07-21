using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SmartLiving.DeviceMVC.BusinessLogics.Migrations
{
    public partial class InitalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "DeviceType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDelete = table.Column<bool>(nullable: false)
                        .Annotation("ColumnOrder", 999),
                    CreateTime = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 997),
                    LastModified = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 998),
                    Name = table.Column<string>(nullable: false),
                    DefaultParams = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDelete = table.Column<bool>(nullable: false)
                        .Annotation("ColumnOrder", 999),
                    CreateTime = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 997),
                    LastModified = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 998),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "House",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDelete = table.Column<bool>(nullable: false)
                        .Annotation("ColumnOrder", 999),
                    CreateTime = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 997),
                    LastModified = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 998),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    HouseTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                    table.ForeignKey(
                        name: "FK_House_HouseType_HouseTypeId",
                        column: x => x.HouseTypeId,
                        principalSchema: "dbo",
                        principalTable: "HouseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDelete = table.Column<bool>(nullable: false)
                        .Annotation("ColumnOrder", 999),
                    CreateTime = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 997),
                    LastModified = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 998),
                    Name = table.Column<string>(nullable: false),
                    HouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_House_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "dbo",
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDelete = table.Column<bool>(nullable: false)
                        .Annotation("ColumnOrder", 999),
                    CreateTime = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 997),
                    LastModified = table.Column<DateTime>(nullable: false)
                        .Annotation("ColumnOrder", 998),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    HouseId = table.Column<int>(nullable: false),
                    DeviceTypeId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: true),
                    Params = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_Area_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Device_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalSchema: "dbo",
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Device_House_HouseId",
                        column: x => x.HouseId,
                        principalSchema: "dbo",
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_HouseId",
                schema: "dbo",
                table: "Area",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_AreaId",
                schema: "dbo",
                table: "Device",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceTypeId",
                schema: "dbo",
                table: "Device",
                column: "DeviceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_HouseId",
                schema: "dbo",
                table: "Device",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_House_HouseTypeId",
                schema: "dbo",
                table: "House",
                column: "HouseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Area",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DeviceType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "House",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HouseType",
                schema: "dbo");
        }
    }
}
