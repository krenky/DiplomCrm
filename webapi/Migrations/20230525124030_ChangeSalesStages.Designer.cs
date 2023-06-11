﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapi.Data;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230525124030_ChangeSalesStages")]
    partial class ChangeSalesStages
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InventoryItemRepairOrder", b =>
                {
                    b.Property<int>("PartsUsedId")
                        .HasColumnType("integer");

                    b.Property<int>("repairOrdersId")
                        .HasColumnType("integer");

                    b.HasKey("PartsUsedId", "repairOrdersId");

                    b.HasIndex("repairOrdersId");

                    b.ToTable("InventoryItemRepairOrder");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RepairOrderRepairWork", b =>
                {
                    b.Property<int>("repairOrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("repairWorksId")
                        .HasColumnType("integer");

                    b.HasKey("repairOrdersId", "repairWorksId");

                    b.HasIndex("repairWorksId");

                    b.ToTable("RepairOrderRepairWork");
                });

            modelBuilder.Entity("webapi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("webapi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("webapi.Models.CustomerHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionHistory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("customerHistories");
                });

            modelBuilder.Entity("webapi.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ModelDevice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("webapi.Models.EmailMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSend")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("EmailMessages");
                });

            modelBuilder.Entity("webapi.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("InventoryItem");
                });

            modelBuilder.Entity("webapi.Models.RepairOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<bool>("LoyaltyDiscount")
                        .HasColumnType("boolean");

                    b.Property<int?>("SalesStagesId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("SalesStagesId");

                    b.ToTable("RepairOrders");
                });

            modelBuilder.Entity("webapi.Models.RepairOrderHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionHistory")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("End")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool?>("LoyaltyDiscount")
                        .HasColumnType("boolean");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("RepairOrderId")
                        .HasColumnType("integer");

                    b.Property<int?>("SalesStagesId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("RepairOrderId");

                    b.ToTable("RepairOrderHistory");
                });

            modelBuilder.Entity("webapi.Models.RepairWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("RepairWorks");
                });

            modelBuilder.Entity("webapi.Models.SalesStages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCancelDefault")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsFirstDefault")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLastDefault")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("NextStagesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NextStagesId");

                    b.ToTable("SalesStages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCancelDefault = false,
                            IsFirstDefault = true,
                            IsLastDefault = false,
                            Name = "Обращение клиента",
                            NextStagesId = 2
                        },
                        new
                        {
                            Id = 2,
                            IsCancelDefault = false,
                            IsFirstDefault = false,
                            IsLastDefault = false,
                            Name = "Приемка устройства",
                            NextStagesId = 3
                        },
                        new
                        {
                            Id = 3,
                            IsCancelDefault = false,
                            IsFirstDefault = false,
                            IsLastDefault = false,
                            Name = "Информирование клиента о стоимости ремонта",
                            NextStagesId = 4
                        },
                        new
                        {
                            Id = 4,
                            IsCancelDefault = false,
                            IsFirstDefault = false,
                            IsLastDefault = false,
                            Name = "Ожидание запчастей",
                            NextStagesId = 5
                        },
                        new
                        {
                            Id = 5,
                            IsCancelDefault = false,
                            IsFirstDefault = false,
                            IsLastDefault = false,
                            Name = "Ремонт",
                            NextStagesId = 6
                        },
                        new
                        {
                            Id = 6,
                            IsCancelDefault = false,
                            IsFirstDefault = false,
                            IsLastDefault = false,
                            Name = "Оплата ремонта",
                            NextStagesId = 7
                        },
                        new
                        {
                            Id = 7,
                            IsCancelDefault = false,
                            IsFirstDefault = false,
                            IsLastDefault = true,
                            Name = "Завершен"
                        },
                        new
                        {
                            Id = 8,
                            IsCancelDefault = true,
                            IsFirstDefault = false,
                            IsLastDefault = false,
                            Name = "Отказ"
                        });
                });

            modelBuilder.Entity("InventoryItemRepairOrder", b =>
                {
                    b.HasOne("webapi.Models.InventoryItem", null)
                        .WithMany()
                        .HasForeignKey("PartsUsedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.RepairOrder", null)
                        .WithMany()
                        .HasForeignKey("repairOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("webapi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("webapi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("webapi.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepairOrderRepairWork", b =>
                {
                    b.HasOne("webapi.Models.RepairOrder", null)
                        .WithMany()
                        .HasForeignKey("repairOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.RepairWork", null)
                        .WithMany()
                        .HasForeignKey("repairWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webapi.Models.CustomerHistory", b =>
                {
                    b.HasOne("webapi.Models.Customer", null)
                        .WithMany("History")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webapi.Models.RepairOrder", b =>
                {
                    b.HasOne("webapi.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("RepairOrders")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("webapi.Models.Customer", "Customer")
                        .WithMany("RepairOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.SalesStages", "SalesStages")
                        .WithMany("Orders")
                        .HasForeignKey("SalesStagesId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Customer");

                    b.Navigation("Device");

                    b.Navigation("SalesStages");
                });

            modelBuilder.Entity("webapi.Models.RepairOrderHistory", b =>
                {
                    b.HasOne("webapi.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.HasOne("webapi.Models.RepairOrder", null)
                        .WithMany("History")
                        .HasForeignKey("RepairOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");
                });

            modelBuilder.Entity("webapi.Models.SalesStages", b =>
                {
                    b.HasOne("webapi.Models.SalesStages", "NextStages")
                        .WithMany()
                        .HasForeignKey("NextStagesId");

                    b.Navigation("NextStages");
                });

            modelBuilder.Entity("webapi.Models.ApplicationUser", b =>
                {
                    b.Navigation("RepairOrders");
                });

            modelBuilder.Entity("webapi.Models.Customer", b =>
                {
                    b.Navigation("History");

                    b.Navigation("RepairOrders");
                });

            modelBuilder.Entity("webapi.Models.RepairOrder", b =>
                {
                    b.Navigation("History");
                });

            modelBuilder.Entity("webapi.Models.SalesStages", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
