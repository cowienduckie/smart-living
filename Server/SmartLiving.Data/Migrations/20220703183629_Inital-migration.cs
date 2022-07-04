using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SmartLiving.Data.Migrations
{
    public partial class Initalmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    LastModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandType",
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
                    Params = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandType", x => x.Id);
                });

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
                    Description = table.Column<string>(nullable: true)
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
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
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
                    UserId = table.Column<string>(nullable: false),
                    IsAllowedOther = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    UserId = table.Column<string>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_House_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SharedWith",
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
                    ProfileId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedWith", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedWith_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "dbo",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SharedWith_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    Status = table.Column<string>(nullable: false),
                    TimeActivated = table.Column<DateTime>(nullable: true),
                    TimeDeactivated = table.Column<DateTime>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "AutoMessage",
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
                    DeviceId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoMessage_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "dbo",
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceData",
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
                    DeviceId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceData_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "dbo",
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileDevice",
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
                    ProfileId = table.Column<int>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfileDevice_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "dbo",
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfileDevice_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "dbo",
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
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
                    UserId = table.Column<string>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false),
                    CommandTypeId = table.Column<int>(nullable: false),
                    Params = table.Column<string>(nullable: false),
                    TimeInterval = table.Column<DateTime>(nullable: true),
                    ActiveFrom = table.Column<DateTime>(nullable: false),
                    ActiveLength = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_CommandType_CommandTypeId",
                        column: x => x.CommandTypeId,
                        principalSchema: "dbo",
                        principalTable: "CommandType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "dbo",
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedule_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Command",
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
                    ScheduleId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: false),
                    DeviceId = table.Column<int>(nullable: false),
                    CommandTypeId = table.Column<int>(nullable: false),
                    Params = table.Column<string>(nullable: false),
                    IsExecuted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Command_CommandType_CommandTypeId",
                        column: x => x.CommandTypeId,
                        principalSchema: "dbo",
                        principalTable: "CommandType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Command_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "dbo",
                        principalTable: "Device",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Command_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalSchema: "dbo",
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Command_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_HouseId",
                schema: "dbo",
                table: "Area",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessage_DeviceId",
                schema: "dbo",
                table: "AutoMessage",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Command_CommandTypeId",
                schema: "dbo",
                table: "Command",
                column: "CommandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Command_DeviceId",
                schema: "dbo",
                table: "Command",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Command_ScheduleId",
                schema: "dbo",
                table: "Command",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Command_UserId",
                schema: "dbo",
                table: "Command",
                column: "UserId");

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
                name: "IX_DeviceData_DeviceId",
                schema: "dbo",
                table: "DeviceData",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_House_HouseTypeId",
                schema: "dbo",
                table: "House",
                column: "HouseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_House_UserId",
                schema: "dbo",
                table: "House",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                schema: "dbo",
                table: "Profile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDevice_DeviceId",
                schema: "dbo",
                table: "ProfileDevice",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDevice_ProfileId",
                schema: "dbo",
                table: "ProfileDevice",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_CommandTypeId",
                schema: "dbo",
                table: "Schedule",
                column: "CommandTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_DeviceId",
                schema: "dbo",
                table: "Schedule",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_UserId",
                schema: "dbo",
                table: "Schedule",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedWith_ProfileId",
                schema: "dbo",
                table: "SharedWith",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedWith_UserId",
                schema: "dbo",
                table: "SharedWith",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "AutoMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Command",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DeviceData",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProfileDevice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SharedWith",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Schedule",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Profile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CommandType",
                schema: "dbo");

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

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
