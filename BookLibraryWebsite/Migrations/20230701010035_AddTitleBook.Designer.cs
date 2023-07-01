﻿// <auto-generated />
using System;
using BookLibraryWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLibraryWebsite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230701010035_AddTitleBook")]
    partial class AddTitleBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookLibraryWebsite.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KindOfBooks")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("discount")
                        .HasColumnType("real");

                    b.Property<string>("filePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            KindOfBooks = 1,
                            Price = 0f,
                            Title = "Book 1",
                            author = "Rami Ali",
                            discount = 0f,
                            filePath = "",
                            photoPath = ""
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            KindOfBooks = 1,
                            Price = 0f,
                            Title = "Book 2",
                            author = "Rami Ali",
                            discount = 0f,
                            filePath = "",
                            photoPath = ""
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            KindOfBooks = 1,
                            Price = 0f,
                            Title = "Book 3",
                            author = "Rami Ali",
                            discount = 0f,
                            filePath = "",
                            photoPath = ""
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            KindOfBooks = 1,
                            Price = 0f,
                            Title = "Book 4",
                            author = "Rami Ali",
                            discount = 0f,
                            filePath = "",
                            photoPath = ""
                        },
                        new
                        {
                            Id = 5,
                            Created = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            KindOfBooks = 1,
                            Price = 0f,
                            Title = "Book 5",
                            author = "Rami Ali",
                            discount = 0f,
                            filePath = "",
                            photoPath = ""
                        },
                        new
                        {
                            Id = 6,
                            Created = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "",
                            KindOfBooks = 1,
                            Price = 0f,
                            Title = "Book 6",
                            author = "Rami Ali",
                            discount = 0f,
                            filePath = "",
                            photoPath = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
