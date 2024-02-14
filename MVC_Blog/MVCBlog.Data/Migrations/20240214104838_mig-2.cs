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
                keyValue: new Guid("9040b5db-87df-4c65-a7bd-633d8e2ddd8e"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d8a86041-b018-4f40-a39d-6851a6b0ee67"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Visitors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("348e6a56-4dd7-4f31-8ccf-2455a2053899"), new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"), new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "Admin", new DateTime(2024, 2, 14, 13, 48, 37, 518, DateTimeKind.Local).AddTicks(2736), null, null, new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"), false, null, null, "ASP.NET Core Article 1", 15 },
                    { new Guid("e1e0687e-9e75-4ba7-82d0-420b042d81bb"), new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"), new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "User", new DateTime(2024, 2, 14, 13, 48, 37, 518, DateTimeKind.Local).AddTicks(2757), null, null, new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"), false, null, null, "Entity Framework Article 2", 25 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("903e68e3-c5be-429a-8ccc-50699a0f8bae"),
                column: "ConcurrencyStamp",
                value: "7e594d73-ea85-417d-9095-86ed56774dc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("930fe77e-f06f-4fa1-a1e1-1be271ce4990"),
                column: "ConcurrencyStamp",
                value: "5810a6a1-9c9e-489b-9f41-0d30276312d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6923b5b-f0d9-4c40-b05c-b0257dd24d76"),
                column: "ConcurrencyStamp",
                value: "b8b4effa-d623-4ef8-a2f2-13ac8ce8ab7d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8073789-6293-443a-bf61-2a1d4c8517f0", "AQAAAAEAACcQAAAAEP9uFUBrzu0csguqOpZ4V9/i0ZzYbmIggaz7vXYNNrj16BZViEzevgnzAzr7Z3cFhA==", "d2156e39-c990-4005-ae4a-555f8418aa2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b76a58f6-6abf-4094-9fda-3d2832f7600d", "AQAAAAEAACcQAAAAEP8NwPIrzGUO7yp7++1tNuYojgFu9ASiwJlyP4OhTSKInrH4i9Aoh3NL0mK+BcnVMg==", "0ed32c8a-ac54-4a69-83b6-c218e7712a4b" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 48, 37, 518, DateTimeKind.Local).AddTicks(3815));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 48, 37, 518, DateTimeKind.Local).AddTicks(3818));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 48, 37, 521, DateTimeKind.Local).AddTicks(4371));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 48, 37, 521, DateTimeKind.Local).AddTicks(4368));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("348e6a56-4dd7-4f31-8ccf-2455a2053899"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e1e0687e-9e75-4ba7-82d0-420b042d81bb"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Visitors");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("9040b5db-87df-4c65-a7bd-633d8e2ddd8e"), new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"), new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "Admin", new DateTime(2024, 2, 14, 13, 19, 30, 825, DateTimeKind.Local).AddTicks(3795), null, null, new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"), false, null, null, "ASP.NET Core Article 1", 15 },
                    { new Guid("d8a86041-b018-4f40-a39d-6851a6b0ee67"), new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"), new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "User", new DateTime(2024, 2, 14, 13, 19, 30, 825, DateTimeKind.Local).AddTicks(3813), null, null, new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"), false, null, null, "Entity Framework Article 2", 25 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("903e68e3-c5be-429a-8ccc-50699a0f8bae"),
                column: "ConcurrencyStamp",
                value: "bfc2d312-4c30-4e63-a4f2-55ce0e42e9f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("930fe77e-f06f-4fa1-a1e1-1be271ce4990"),
                column: "ConcurrencyStamp",
                value: "7206b6e6-7a4f-42f0-a870-d99ab80c2b36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d6923b5b-f0d9-4c40-b05c-b0257dd24d76"),
                column: "ConcurrencyStamp",
                value: "64e33b52-f8b3-43ba-9466-b50e156fa496");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c28b3ac3-d764-4dcd-810b-4caf0b9ae2d5", "AQAAAAEAACcQAAAAEFQXxLQkRbUwVwuRjL4fRipnVcOXAL38FR9oZxsPu5SY0PIOYcxDgrhgsKslwuYU3g==", "482bcae5-f49a-496b-a581-4056146e8239" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5d2fcfd9-cb59-41ec-9d9b-74a7aea9b949", "AQAAAAEAACcQAAAAELstQFV7AE+c+G1nIpP4vA79COuO5SbBgLLXdcqT902GKVzkz3X/G6P5El6yxc2YOQ==", "94ce2ff4-ba5c-442e-9510-0f0e0a4e4a8b" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 19, 30, 825, DateTimeKind.Local).AddTicks(4841));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 19, 30, 825, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 19, 30, 828, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 14, 13, 19, 30, 828, DateTimeKind.Local).AddTicks(6505));
        }
    }
}
