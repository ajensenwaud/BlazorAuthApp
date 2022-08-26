using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TxB.Migrations
{
    public partial class initscript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Is18OrAbove = table.Column<bool>(type: "INTEGER", nullable: false),
                    ActivationKey = table.Column<string>(type: "TEXT", nullable: false),
                    ResetKey = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TopicName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WordType = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    TopicId = table.Column<long>(type: "INTEGER", nullable: false),
                    SubmittedById = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Words_AspNetUsers_SubmittedById",
                        column: x => x.SubmittedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Words_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Propositions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ajective0Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Ajective1Id = table.Column<long>(type: "INTEGER", nullable: false),
                    Ajective2Id = table.Column<long>(type: "INTEGER", nullable: false),
                    NounId = table.Column<long>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TopicId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Propositions_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propositions_Words_Ajective0Id",
                        column: x => x.Ajective0Id,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propositions_Words_Ajective1Id",
                        column: x => x.Ajective1Id,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propositions_Words_Ajective2Id",
                        column: x => x.Ajective2Id,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Propositions_Words_NounId",
                        column: x => x.NounId,
                        principalTable: "Words",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PropositionId = table.Column<long>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Propositions_PropositionId",
                        column: x => x.PropositionId,
                        principalTable: "Propositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Topics",
                columns: new[] { "Id", "TopicName" },
                values: new object[] { 1L, "Tech" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "TopicName" },
                values: new object[] { 2L, "TxB" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1ffceb74-223b-4eef-bf92-973965ecbfc6"), new Guid("1aa53628-0b81-492b-b674-9ca18522b918") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8b12fcdd-53b9-43bd-85e4-b97fa0493cf7"), new Guid("1aa53628-0b81-492b-b674-9ca18522b918") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_Ajective0Id",
                table: "Propositions",
                column: "Ajective0Id");

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_Ajective1Id",
                table: "Propositions",
                column: "Ajective1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_Ajective2Id",
                table: "Propositions",
                column: "Ajective2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_NounId",
                table: "Propositions",
                column: "NounId");

            migrationBuilder.CreateIndex(
                name: "IX_Propositions_TopicId",
                table: "Propositions",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PropositionId",
                table: "Ratings",
                column: "PropositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Words_SubmittedById",
                table: "Words",
                column: "SubmittedById");

            migrationBuilder.CreateIndex(
                name: "IX_Words_TopicId",
                table: "Words",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Propositions");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
