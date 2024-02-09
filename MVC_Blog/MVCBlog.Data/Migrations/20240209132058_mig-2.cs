using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBlog.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("51c431ff-e1b3-4660-8114-cec099ca0a02"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8e185bba-7906-4117-ab3e-4769cc5007fb"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2d0dd9d2-caaa-48c2-bb8b-f9c16a9dcec2"), new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "User", new DateTime(2024, 2, 9, 16, 20, 58, 288, DateTimeKind.Local).AddTicks(2375), null, null, new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"), false, null, null, "Entity Framework Article 2", 25 },
                    { new Guid("56672911-1a83-4b93-ae23-75d2278f6654"), new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "Admin", new DateTime(2024, 2, 9, 16, 20, 58, 288, DateTimeKind.Local).AddTicks(2355), null, null, new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"), false, null, null, "ASP.NET Core Article 1", 15 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("903e68e3-c5be-429a-8ccc-50699a0f8bae"), "4f21ea80-cc09-43a0-aa03-640453cb0313", "Admin", "ADMIN" },
                    { new Guid("930fe77e-f06f-4fa1-a1e1-1be271ce4990"), "6fa3983d-e188-4a71-a72c-a339df20a8e0", "SuperAdmin", "SUPERADMIN" },
                    { new Guid("d6923b5b-f0d9-4c40-b05c-b0257dd24d76"), "369815f0-08f3-4898-b193-7f2ad9ba986b", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"), 0, "79fcb470-846e-477a-9dca-8fbb0b635029", "superadmin@gmail.com", true, "Hakan", "Yavaş", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEJYEh2lIvgR0QMeSWcv1XZ+Be7uyd8okicD3u9f5U7+qbSU4rE7ER71LtkR34tfUSQ==", "+905400000000", true, "584c58db-8288-4a14-a4db-da39d4956cd1", false, "superadmin@gmail.com" },
                    { new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"), 0, "da89e804-7203-4168-ad6b-d9f03971d0f8", "admin@gmail.com", true, "Alperen", "Güneş", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELRQhgReK+phg6rBkQORRRIH/y9L1AEXEyRe9NW+nLTeA3qsPodAC2sc7CMzNRUgEg==", "+905400000001", true, "b65cdd0c-dd7a-4c2c-a703-eea2148afdc5", false, "admin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 16, 20, 58, 288, DateTimeKind.Local).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 16, 20, 58, 288, DateTimeKind.Local).AddTicks(2615));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 16, 20, 58, 291, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 16, 20, 58, 291, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("930fe77e-f06f-4fa1-a1e1-1be271ce4990"), new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("903e68e3-c5be-429a-8ccc-50699a0f8bae"), new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a") });

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

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2d0dd9d2-caaa-48c2-bb8b-f9c16a9dcec2"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("56672911-1a83-4b93-ae23-75d2278f6654"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("51c431ff-e1b3-4660-8114-cec099ca0a02"), new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "Admin", new DateTime(2024, 2, 9, 11, 50, 7, 714, DateTimeKind.Local).AddTicks(2200), null, null, new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"), false, null, null, "ASP.NET Core Article 1", 15 },
                    { new Guid("8e185bba-7906-4117-ab3e-4769cc5007fb"), new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "User", new DateTime(2024, 2, 9, 11, 50, 7, 714, DateTimeKind.Local).AddTicks(2217), null, null, new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"), false, null, null, "Entity Framework Article 2", 25 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 11, 50, 7, 714, DateTimeKind.Local).AddTicks(2452));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 11, 50, 7, 714, DateTimeKind.Local).AddTicks(2457));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 11, 50, 7, 714, DateTimeKind.Local).AddTicks(2575));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 9, 11, 50, 7, 714, DateTimeKind.Local).AddTicks(2558));
        }
    }
}
