using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartLiving.Data.Migrations
{
    public partial class UpdateCreateDeviceFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Params",
                schema: "dbo",
                table: "CommandType");

            migrationBuilder.AddColumn<string>(
                name: "DefaultParams",
                schema: "dbo",
                table: "CommandType",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DeviceCommandTypes",
                columns: table => new
                {
                    DeviceId = table.Column<int>(nullable: false),
                    CommandTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCommandTypes", x => new { x.DeviceId, x.CommandTypeId });
                    table.ForeignKey(
                        name: "FK_DeviceCommandTypes_CommandType_CommandTypeId",
                        column: x => x.CommandTypeId,
                        principalSchema: "dbo",
                        principalTable: "CommandType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceCommandTypes_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "dbo",
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceTypeCommandTypes",
                columns: table => new
                {
                    DeviceTypeId = table.Column<int>(nullable: false),
                    CommandTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypeCommandTypes", x => new { x.DeviceTypeId, x.CommandTypeId });
                    table.ForeignKey(
                        name: "FK_DeviceTypeCommandTypes_CommandType_CommandTypeId",
                        column: x => x.CommandTypeId,
                        principalSchema: "dbo",
                        principalTable: "CommandType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeviceTypeCommandTypes_DeviceType_DeviceTypeId",
                        column: x => x.DeviceTypeId,
                        principalSchema: "dbo",
                        principalTable: "DeviceType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCommandTypes_CommandTypeId",
                table: "DeviceCommandTypes",
                column: "CommandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceTypeCommandTypes_CommandTypeId",
                table: "DeviceTypeCommandTypes",
                column: "CommandTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceCommandTypes");

            migrationBuilder.DropTable(
                name: "DeviceTypeCommandTypes");

            migrationBuilder.DropColumn(
                name: "DefaultParams",
                schema: "dbo",
                table: "CommandType");

            migrationBuilder.AddColumn<string>(
                name: "Params",
                schema: "dbo",
                table: "CommandType",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
