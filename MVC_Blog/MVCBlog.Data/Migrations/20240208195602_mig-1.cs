using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBlog.Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"), "Admin", new DateTime(2024, 2, 8, 22, 56, 2, 577, DateTimeKind.Local).AddTicks(5917), null, null, false, null, null, "ASP.Net Core" },
                    { new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"), "Admin", new DateTime(2024, 2, 8, 22, 56, 2, 577, DateTimeKind.Local).AddTicks(5920), null, null, false, null, null, "Entity Framework" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"), "Admin", new DateTime(2024, 2, 8, 22, 56, 2, 577, DateTimeKind.Local).AddTicks(6076), null, null, "entityframework.jpg", "image/jpeg", false, null, null },
                    { new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"), "Admin", new DateTime(2024, 2, 8, 22, 56, 2, 577, DateTimeKind.Local).AddTicks(6062), null, null, "aspnetcore.jpg", "image/jpeg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("76af112e-8a27-49ff-bf3b-20c1db196385"), new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "User", new DateTime(2024, 2, 8, 22, 56, 2, 577, DateTimeKind.Local).AddTicks(5703), null, null, new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"), false, null, null, "Entity Framework Article 2", 25 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { new Guid("f9de7f35-2d51-42e2-9674-ce3aa2b8c7a5"), new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.", "Admin", new DateTime(2024, 2, 8, 22, 56, 2, 577, DateTimeKind.Local).AddTicks(5686), null, null, new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"), false, null, null, "ASP.NET Core Article 1", 15 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
