﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.Data;

#nullable disable

namespace BlazorAppempty23.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250529075812_InitialCreate4")]
    partial class InitialCreate4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Shared.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 5, 29, 7, 58, 12, 106, DateTimeKind.Utc).AddTicks(2282),
                            Description = "Мощный ноутбук",
                            ImageUrl = "",
                            Name = "Ноутбук",
                            Price = 999.99m,
                            StockQuantity = 10,
                            UpdatedAt = new DateTime(2025, 5, 29, 7, 58, 12, 106, DateTimeKind.Utc).AddTicks(2285)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 5, 29, 7, 58, 12, 106, DateTimeKind.Utc).AddTicks(2296),
                            Description = "Флагманский смартфон",
                            ImageUrl = "",
                            Name = "Смартфон",
                            Price = 799.99m,
                            StockQuantity = 15,
                            UpdatedAt = new DateTime(2025, 5, 29, 7, 58, 12, 106, DateTimeKind.Utc).AddTicks(2297)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
