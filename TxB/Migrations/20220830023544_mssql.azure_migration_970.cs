using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TxB.Migrations
{
    public partial class mssqlazure_migration_970 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("864e6910-925f-4cef-b1cc-258e592a376c"), new Guid("6d32c0f0-0e91-4e22-80de-71105dc54a8a") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ecb15d95-f0b2-4b4b-97ee-51ba5cf78756"), new Guid("6d32c0f0-0e91-4e22-80de-71105dc54a8a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("864e6910-925f-4cef-b1cc-258e592a376c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ecb15d95-f0b2-4b4b-97ee-51ba5cf78756"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d32c0f0-0e91-4e22-80de-71105dc54a8a"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b220aec4-87d7-4640-9dc3-18f641d99f0f"), "9367b118-a3b9-4116-b1b8-b2abcd85b59f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f996ef7b-24f2-4c31-a69a-d39dc0bee721"), "9663f319-ad2d-4027-ac0f-c14fa7636f0c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationKey", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Is18OrAbove", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetKey", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("e229df1a-0941-4ba6-b234-37828ae475e2"), 0, "", "", new DateTime(2022, 8, 30, 10, 35, 44, 395, DateTimeKind.Local).AddTicks(7587), "anders@jensenwaud.com", true, "Anders Admin", true, "Jensen", false, null, "anders@jensenwaud.com", "Admin", "AQAAAAEAACcQAAAAEFj+UUInmGyNCEAl1WScalAy+mVMhOVAQuGlJlgd8DdwzNC2And9FteVYeB+8J6ILA==", "00000000", true, "", "", false, new DateTime(2022, 8, 30, 10, 35, 44, 395, DateTimeKind.Local).AddTicks(7606), "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b220aec4-87d7-4640-9dc3-18f641d99f0f"), new Guid("e229df1a-0941-4ba6-b234-37828ae475e2") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f996ef7b-24f2-4c31-a69a-d39dc0bee721"), new Guid("e229df1a-0941-4ba6-b234-37828ae475e2") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b220aec4-87d7-4640-9dc3-18f641d99f0f"), new Guid("e229df1a-0941-4ba6-b234-37828ae475e2") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f996ef7b-24f2-4c31-a69a-d39dc0bee721"), new Guid("e229df1a-0941-4ba6-b234-37828ae475e2") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b220aec4-87d7-4640-9dc3-18f641d99f0f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f996ef7b-24f2-4c31-a69a-d39dc0bee721"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e229df1a-0941-4ba6-b234-37828ae475e2"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("864e6910-925f-4cef-b1cc-258e592a376c"), "bef0fd24-d4c3-4ec6-b094-c6325aedaed5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ecb15d95-f0b2-4b4b-97ee-51ba5cf78756"), "3d0ec95f-fa54-43fb-b064-ed28a1194af8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationKey", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Is18OrAbove", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetKey", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("6d32c0f0-0e91-4e22-80de-71105dc54a8a"), 0, "", "", new DateTime(2022, 8, 30, 10, 22, 50, 960, DateTimeKind.Local).AddTicks(2766), "anders@jensenwaud.com", true, "Anders Admin", true, "Jensen", false, null, "anders@jensenwaud.com", "Admin", "AQAAAAEAACcQAAAAEOiR0R5xFDgG02e8OTI3Z7EQhKjvWUxjDTgHKWaWrq5PpBTcOgwv7sD0a329RTDUVg==", "00000000", true, "", "", false, new DateTime(2022, 8, 30, 10, 22, 50, 960, DateTimeKind.Local).AddTicks(2777), "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("864e6910-925f-4cef-b1cc-258e592a376c"), new Guid("6d32c0f0-0e91-4e22-80de-71105dc54a8a") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ecb15d95-f0b2-4b4b-97ee-51ba5cf78756"), new Guid("6d32c0f0-0e91-4e22-80de-71105dc54a8a") });
        }
    }
}
