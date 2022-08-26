using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TxB.Migrations
{
    public partial class @ref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("93a02e32-baef-4839-852e-1cd21fa7d53d"), "06252b48-f4eb-4b0e-80b1-638dc24732b0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ac696617-d231-4ffc-9bb8-360045cf36a2"), "d5a8efe9-629e-4483-8153-dc696e0b8a3b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ActivationKey", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Is18OrAbove", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ResetKey", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[] { new Guid("d4d55e23-eb6e-4249-acb3-b3fe2af66248"), 0, "", "", new DateTime(2022, 8, 26, 9, 3, 39, 75, DateTimeKind.Local).AddTicks(396), "anders@jensenwaud.com", true, "Anders Admin", true, "Jensen", false, null, "anders@jensenwaud.com", "Admin", "AQAAAAEAACcQAAAAEOFvgDKlq4jHYK/tEB1GEwYtDFH4+Lq4iiYkbKzD6vphp0ftywONqt3DcpffdKKIQQ==", "00000000", true, "", "", false, new DateTime(2022, 8, 26, 9, 3, 39, 75, DateTimeKind.Local).AddTicks(407), "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("93a02e32-baef-4839-852e-1cd21fa7d53d"), new Guid("d4d55e23-eb6e-4249-acb3-b3fe2af66248") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ac696617-d231-4ffc-9bb8-360045cf36a2"), new Guid("d4d55e23-eb6e-4249-acb3-b3fe2af66248") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("93a02e32-baef-4839-852e-1cd21fa7d53d"), new Guid("d4d55e23-eb6e-4249-acb3-b3fe2af66248") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ac696617-d231-4ffc-9bb8-360045cf36a2"), new Guid("d4d55e23-eb6e-4249-acb3-b3fe2af66248") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93a02e32-baef-4839-852e-1cd21fa7d53d"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ac696617-d231-4ffc-9bb8-360045cf36a2"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4d55e23-eb6e-4249-acb3-b3fe2af66248"));

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
        }
    }
}
