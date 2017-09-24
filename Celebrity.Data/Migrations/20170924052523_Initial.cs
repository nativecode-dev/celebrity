using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Celebrity.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Slug = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    UserCreated = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserModified = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    Website = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    NormalizedName = table.Column<string>(type: "longtext", nullable: true),
                    UserCreated = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserModified = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ApiToken = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserCreated = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserModified = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebHooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Url = table.Column<string>(type: "varchar(2083)", maxLength: 2083, nullable: false),
                    UserCreated = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserModified = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebHooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebHooks_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserCreated = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserModified = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationUsers_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserCreated = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserModified = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebHookParameter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    DateModified = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    UserCreated = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    UserModified = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    Value = table.Column<string>(type: "longtext", nullable: true),
                    WebHookId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebHookParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebHookParameter_WebHooks_WebHookId",
                        column: x => x.WebHookId,
                        principalTable: "WebHooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_OrganizationId",
                table: "OrganizationUsers",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationUsers_UserId",
                table: "OrganizationUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WebHookParameter_WebHookId",
                table: "WebHookParameter",
                column: "WebHookId");

            migrationBuilder.CreateIndex(
                name: "IX_WebHooks_OrganizationId",
                table: "WebHooks",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrganizationUsers");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "WebHookParameter");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WebHooks");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
