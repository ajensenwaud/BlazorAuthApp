using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TxB.Migrations
{
    public partial class statuscol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propositions_Words_Ajective0Id",
                table: "Propositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Propositions_Words_Ajective1Id",
                table: "Propositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Propositions_Words_Ajective2Id",
                table: "Propositions");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("1ffceb74-223b-4eef-bf92-973965ecbfc6"), new Guid("1aa53628-0b81-492b-b674-9ca18522b918") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8b12fcdd-53b9-43bd-85e4-b97fa0493cf7"), new Guid("1aa53628-0b81-492b-b674-9ca18522b918") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ffceb74-223b-4eef-bf92-973965ecbfc6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b12fcdd-53b9-43bd-85e4-b97fa0493cf7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1aa53628-0b81-492b-b674-9ca18522b918"));

            migrationBuilder.RenameColumn(
                name: "Ajective2Id",
                table: "Propositions",
                newName: "Adjective2Id");

            migrationBuilder.RenameColumn(
                name: "Ajective1Id",
                table: "Propositions",
                newName: "Adjective1Id");

            migrationBuilder.RenameColumn(
                name: "Ajective0Id",
                table: "Propositions",
                newName: "Adjective0Id");

            migrationBuilder.RenameIndex(
                name: "IX_Propositions_Ajective2Id",
                table: "Propositions",
                newName: "IX_Propositions_Adjective2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Propositions_Ajective1Id",
                table: "Propositions",
                newName: "IX_Propositions_Adjective1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Propositions_Ajective0Id",
                table: "Propositions",
                newName: "IX_Propositions_Adjective0Id");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Words",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("aa077a5f-8c56-475a-b71c-c95751bb8f5e"), "ed2f6dc5-67d2-45a0-bc1d-13dfe8561f7a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("fe3e2265-830f-4ed1-b8e7-09770e36ef08"), "edcfa822-821a-41a1-86ed-ca83eb526330", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationKey", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Is18OrAbove", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetKey", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("d8273b58-cb8b-43a2-bde6-937ccdf3e2c3"), 0, "", "", new DateTime(2022, 8, 23, 12, 39, 27, 942, DateTimeKind.Local).AddTicks(9390), "anders@jensenwaud.com", true, "Anders Admin", true, "Jensen", false, null, "anders@jensenwaud.com", "Admin", "AQAAAAEAACcQAAAAEFIWYpwPsgVxCnZ31SAd/KeWYFws5JjxpN4zfeEqI1fOZK9dGHOw1yvuxHERYr0pcg==", "00000000", true, "", "", false, new DateTime(2022, 8, 23, 12, 39, 27, 942, DateTimeKind.Local).AddTicks(9402), "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("aa077a5f-8c56-475a-b71c-c95751bb8f5e"), new Guid("d8273b58-cb8b-43a2-bde6-937ccdf3e2c3") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("fe3e2265-830f-4ed1-b8e7-09770e36ef08"), new Guid("d8273b58-cb8b-43a2-bde6-937ccdf3e2c3") });

            migrationBuilder.AddForeignKey(
                name: "FK_Propositions_Words_Adjective0Id",
                table: "Propositions",
                column: "Adjective0Id",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propositions_Words_Adjective1Id",
                table: "Propositions",
                column: "Adjective1Id",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propositions_Words_Adjective2Id",
                table: "Propositions",
                column: "Adjective2Id",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propositions_Words_Adjective0Id",
                table: "Propositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Propositions_Words_Adjective1Id",
                table: "Propositions");

            migrationBuilder.DropForeignKey(
                name: "FK_Propositions_Words_Adjective2Id",
                table: "Propositions");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("aa077a5f-8c56-475a-b71c-c95751bb8f5e"), new Guid("d8273b58-cb8b-43a2-bde6-937ccdf3e2c3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fe3e2265-830f-4ed1-b8e7-09770e36ef08"), new Guid("d8273b58-cb8b-43a2-bde6-937ccdf3e2c3") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa077a5f-8c56-475a-b71c-c95751bb8f5e"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fe3e2265-830f-4ed1-b8e7-09770e36ef08"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d8273b58-cb8b-43a2-bde6-937ccdf3e2c3"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Words");

            migrationBuilder.RenameColumn(
                name: "Adjective2Id",
                table: "Propositions",
                newName: "Ajective2Id");

            migrationBuilder.RenameColumn(
                name: "Adjective1Id",
                table: "Propositions",
                newName: "Ajective1Id");

            migrationBuilder.RenameColumn(
                name: "Adjective0Id",
                table: "Propositions",
                newName: "Ajective0Id");

            migrationBuilder.RenameIndex(
                name: "IX_Propositions_Adjective2Id",
                table: "Propositions",
                newName: "IX_Propositions_Ajective2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Propositions_Adjective1Id",
                table: "Propositions",
                newName: "IX_Propositions_Ajective1Id");

            migrationBuilder.RenameIndex(
                name: "IX_Propositions_Adjective0Id",
                table: "Propositions",
                newName: "IX_Propositions_Ajective0Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("1ffceb74-223b-4eef-bf92-973965ecbfc6"), "ccda70e3-ef6a-46a2-8992-dc2910089a3d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("8b12fcdd-53b9-43bd-85e4-b97fa0493cf7"), "fb3ca6ac-849f-4ff3-b368-52a580dc0074", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationKey", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Is18OrAbove", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetKey", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("1aa53628-0b81-492b-b674-9ca18522b918"), 0, "", "", new DateTime(2022, 8, 20, 18, 16, 49, 434, DateTimeKind.Local).AddTicks(9610), "anders@jensenwaud.com", true, "Anders Admin", true, "Jensen", false, null, "anders@jensenwaud.com", "Admin", "AQAAAAEAACcQAAAAEK251DLdLqLwboManutLnf8VXvUsoXFlDTXB19p9vuPsHLueOTwpphGXMy6Zxdq5jQ==", "00000000", true, "", "", false, new DateTime(2022, 8, 20, 18, 16, 49, 434, DateTimeKind.Local).AddTicks(9623), "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1ffceb74-223b-4eef-bf92-973965ecbfc6"), new Guid("1aa53628-0b81-492b-b674-9ca18522b918") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8b12fcdd-53b9-43bd-85e4-b97fa0493cf7"), new Guid("1aa53628-0b81-492b-b674-9ca18522b918") });

            migrationBuilder.AddForeignKey(
                name: "FK_Propositions_Words_Ajective0Id",
                table: "Propositions",
                column: "Ajective0Id",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propositions_Words_Ajective1Id",
                table: "Propositions",
                column: "Ajective1Id",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propositions_Words_Ajective2Id",
                table: "Propositions",
                column: "Ajective2Id",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
