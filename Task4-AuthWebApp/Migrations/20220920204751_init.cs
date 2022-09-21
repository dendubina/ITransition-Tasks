using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task4AuthWebApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastSignInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SignUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastSignInDate", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SignUpDate", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "853250a1-d5f2-4330-bf98-b446d061cb19", 0, "579eaf6e-3ae5-44c5-864a-36943f1979ea", "london_lesc3@gmail.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 344, DateTimeKind.Local).AddTicks(771), false, null, null, null, null, null, false, "9da61019-6f1e-4c85-8ecf-634d155f436c", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(4677), 1, false, "Genie" },
                    { "1363ae6c-597e-47f5-84e6-96917a926231", 0, "bb0ffb18-f4d9-4e43-b834-a908465dc097", "haylee.nitzsc@yahoo.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5683), false, null, null, null, null, null, false, "35cd8052-0fa9-4249-b858-614aca3e6b0c", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5689), 0, false, "Anthony" },
                    { "f9929caf-fae3-46f9-af53-22cba9f54ae9", 0, "5fba9b2f-163a-4b6c-988c-7ec1fdc8773f", "harvey1982@hotmail.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5714), false, null, null, null, null, null, false, "48189ac2-87fa-4887-843d-be0b2e21fdb3", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5715), 0, false, "Kelly" },
                    { "bf8d6112-e4c9-44eb-b5cc-29f437d89032", 0, "ffa067b2-bc94-41ac-b77b-34fc0b4dd6df", "daisy_bernha@gmail.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5724), false, null, null, null, null, null, false, "bd5f4a35-bbfc-4a64-9cb5-506cd7e1bfa9", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5725), 0, false, "Paul" },
                    { "e3b655e1-af48-4710-86c3-a49322d366b8", 0, "c9a5137a-2b1b-4921-a637-2a1bc6949fee", "rosa_turne6@gmail.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5734), false, null, null, null, null, null, false, "8722a07a-bf49-4fe7-bb2c-cb1f3bcc38be", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5735), 0, false, "Freida" },
                    { "060a25b8-398f-45af-b696-c73b59b9f9d5", 0, "d7e582ff-25e3-4490-9488-7aebe5d7cd3a", "colin_lin6@hotmail.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5753), false, null, null, null, null, null, false, "c343c185-ac70-475c-92d9-88b61c58f675", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5755), 0, false, "Margaret" },
                    { "60f68b9e-21fc-4caf-a8f6-2c3ce1c9435e", 0, "9ef7021b-9a51-426e-aaa5-a0806efbd7e6", "arjun_kertzma@gmail.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5763), false, null, null, null, null, null, false, "2a918893-1ef1-43fa-941a-3beb8acad132", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5764), 0, false, "Peter" },
                    { "15094e1d-7cf8-4f8e-bdb4-a301eacb9597", 0, "85ccddda-b39c-4efa-8f75-f754038bc4da", "emil2002@hotmail.com", false, new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5773), false, null, null, null, null, null, false, "4dc19657-9197-4936-8e9f-2539b194b9d9", new DateTime(2022, 9, 20, 23, 47, 51, 345, DateTimeKind.Local).AddTicks(5774), 0, false, "Deloris" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
