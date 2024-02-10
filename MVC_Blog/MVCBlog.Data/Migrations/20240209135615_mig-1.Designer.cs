﻿// <auto-generated />
using System;
using MVCBlog.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCBlog.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240209135615_mig-1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCBlog.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("48c16ef7-3d34-4076-b9ad-be164fa6ae41"),
                            AppUserId = new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"),
                            CategoryId = new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"),
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.",
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 9, 16, 56, 14, 846, DateTimeKind.Local).AddTicks(5365),
                            ImageId = new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"),
                            IsDeleted = false,
                            Title = "ASP.NET Core Article 1",
                            ViewCount = 15
                        },
                        new
                        {
                            Id = new Guid("2a8f6c9a-ee2c-4fc8-8a80-920b70c0e053"),
                            AppUserId = new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"),
                            CategoryId = new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"),
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur auctor imperdiet faucibus. In hac habitasse platea dictumst. \r\n							Sed porttitor, nulla ac elementum placerat, felis justo ullamcorper est, et pulvinar nulla velit non risus. \r\n							Proin ac aliquam turpis. Suspendisse non nisi dapibus, viverra lacus nec, fringilla tellus. Donec efficitur lorem ac lacus pharetra sagittis. \r\n							Fusce viverra est vitae quam vulputate, at ornare nisl accumsan. Duis a tincidunt lorem. In nibh lectus, pharetra ac quam.",
                            CreatedBy = "User",
                            CreatedDate = new DateTime(2024, 2, 9, 16, 56, 14, 846, DateTimeKind.Local).AddTicks(5380),
                            ImageId = new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"),
                            IsDeleted = false,
                            Title = "Entity Framework Article 2",
                            ViewCount = 25
                        });
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5129fa7-7cb3-421a-b6b8-de983725a187"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 9, 16, 56, 14, 846, DateTimeKind.Local).AddTicks(5557),
                            IsDeleted = false,
                            Name = "ASP.Net Core"
                        },
                        new
                        {
                            Id = new Guid("efaf03fc-92eb-45d7-8980-7c75d5a5ea8c"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 9, 16, 56, 14, 846, DateTimeKind.Local).AddTicks(5560),
                            IsDeleted = false,
                            Name = "Entity Framework"
                        });
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("930fe77e-f06f-4fa1-a1e1-1be271ce4990"),
                            ConcurrencyStamp = "913e8626-f238-4757-8e6a-221760205101",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("903e68e3-c5be-429a-8ccc-50699a0f8bae"),
                            ConcurrencyStamp = "b8eb114d-e178-45dd-97c1-8ac270bfbe00",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("d6923b5b-f0d9-4c40-b05c-b0257dd24d76"),
                            ConcurrencyStamp = "7926451c-c8d1-4efd-90ef-f694ffc0de03",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d0fd9fd8-595b-4f32-a2aa-d0205be01395",
                            Email = "superadmin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Hakan",
                            ImageId = new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"),
                            LastName = "Yavaş",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@GMAIL.COM",
                            NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEoZm/Z5Ndo+kWL91LdBawAPQM/WtGIEZWVkWRe6xoCt+jxzxjkjvuypfZqGv3RFMw==",
                            PhoneNumber = "+905400000000",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "72197772-00a3-4c77-9f1e-beecd58b7295",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@gmail.com"
                        },
                        new
                        {
                            Id = new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "988a8a85-9a21-4a13-822b-7c7852024299",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Alperen",
                            ImageId = new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"),
                            LastName = "Güneş",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMxJevC8TCdkoFMBWzYo27NQ+3GK2kDtJWKHDeXBcPu0C9uhUNsrx1o3O/9XuueWbg==",
                            PhoneNumber = "+905400000001",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "1462aeb6-7874-4c59-b7af-ecf797bcb21a",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("7893082f-7266-41f5-8e2c-d89989ee60d0"),
                            RoleId = new Guid("930fe77e-f06f-4fa1-a1e1-1be271ce4990")
                        },
                        new
                        {
                            UserId = new Guid("84ccaf88-5507-4dbf-8ddd-8f607db51f0a"),
                            RoleId = new Guid("903e68e3-c5be-429a-8ccc-50699a0f8bae")
                        });
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AppUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("906d333c-201d-4b39-8e21-52a3acc1ff73"),
                            AppUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 9, 16, 56, 14, 849, DateTimeKind.Local).AddTicks(7295),
                            FileName = "aspnetcore.jpg",
                            FileType = "image/jpeg",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("3edbde25-8f71-4834-ac2d-c1665c10bc63"),
                            AppUserId = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 9, 16, 56, 14, 849, DateTimeKind.Local).AddTicks(7298),
                            FileName = "entityframework.jpg",
                            FileType = "image/jpeg",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Article", b =>
                {
                    b.HasOne("MVCBlog.Entity.Entities.Identity.AppUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBlog.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBlog.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId");

                    b.Navigation("Category");

                    b.Navigation("Image");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppRoleClaim", b =>
                {
                    b.HasOne("MVCBlog.Entity.Entities.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUser", b =>
                {
                    b.HasOne("MVCBlog.Entity.Entities.Image", "Image")
                        .WithMany("Users")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserClaim", b =>
                {
                    b.HasOne("MVCBlog.Entity.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserLogin", b =>
                {
                    b.HasOne("MVCBlog.Entity.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserRole", b =>
                {
                    b.HasOne("MVCBlog.Entity.Entities.Identity.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCBlog.Entity.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUserToken", b =>
                {
                    b.HasOne("MVCBlog.Entity.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Identity.AppUser", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("MVCBlog.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}