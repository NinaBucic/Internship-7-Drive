﻿// <auto-generated />
using System;
using Drive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Drive.Data.Migrations
{
    [DbContext(typeof(DriveDbContext))]
    [Migration("20250101222655_AddSeedData")]
    partial class AddSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Drive.Data.Entities.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FileId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 2,
                            Content = "Looks good!",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2136),
                            FileId = 1,
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2138)
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 3,
                            Content = "Needs some changes.",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2160),
                            FileId = 1,
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2161)
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 4,
                            Content = "Great work!",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2165),
                            FileId = 5,
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(2166)
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("FolderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Work report content",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1931),
                            FolderId = 1,
                            LastModifiedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1933),
                            Name = "report.docx",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1949),
                            FolderId = 2,
                            LastModifiedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1950),
                            Name = "photo.jpg",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "Collaborative notes",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1955),
                            FolderId = 3,
                            LastModifiedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1956),
                            Name = "shared_notes.txt",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1960),
                            FolderId = 4,
                            LastModifiedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1961),
                            Name = "image1.png",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 5,
                            Content = "Project tasks content",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1965),
                            FolderId = 5,
                            LastModifiedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1967),
                            Name = "tasks.txt",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 6,
                            Content = "File in root directory",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1983),
                            LastModifiedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1984),
                            Name = "root_file_1.txt",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 7,
                            Content = "File in root directory",
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1987),
                            LastModifiedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1989),
                            Name = "root_file_2.txt",
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentFolderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1688),
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1691),
                            Name = "Work",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1729),
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1730),
                            Name = "Personal",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1735),
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1736),
                            Name = "Shared Folder",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1740),
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1741),
                            Name = "Images",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1745),
                            LastModified = new DateTime(2025, 1, 1, 22, 26, 54, 643, DateTimeKind.Utc).AddTicks(1746),
                            Name = "Projects",
                            OwnerId = 1,
                            ParentFolderId = 1
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.SharedItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("FileId")
                        .HasColumnType("integer");

                    b.Property<int?>("FolderId")
                        .HasColumnType("integer");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("FolderId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RecipientId");

                    b.ToTable("SharedItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FileId = 3,
                            OwnerId = 1,
                            RecipientId = 2
                        },
                        new
                        {
                            Id = 2,
                            FolderId = 3,
                            OwnerId = 1,
                            RecipientId = 3
                        },
                        new
                        {
                            Id = 3,
                            FolderId = 4,
                            OwnerId = 3,
                            RecipientId = 4
                        },
                        new
                        {
                            Id = 4,
                            FolderId = 2,
                            OwnerId = 2,
                            RecipientId = 1
                        },
                        new
                        {
                            Id = 5,
                            FileId = 6,
                            OwnerId = 1,
                            RecipientId = 3
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "alice@gmail.com",
                            Password = "$2a$11$NA.uy5h1/kKDz39P02BlDuOg1K4RGY0u/8chuwa8mqPJ5Dwxo4toq"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bob@gmail.com",
                            Password = "$2a$11$5IMXWaVt4EbLN78tow4iguGudMaQNF2VX44WW0nsOc5RGkJRLc9Om"
                        },
                        new
                        {
                            Id = 3,
                            Email = "charlie@gmail.com",
                            Password = "$2a$11$K3xBfB6SI3teTBqpujYEY.zdDr2lnXfOz426Y3kIoukfqtGizVy/q"
                        },
                        new
                        {
                            Id = 4,
                            Email = "frane@gmail.com",
                            Password = "$2a$11$ipBvBnjYrK0J33U1V/kkQ.w1od/OX9aYYM87lJ6HbTIKzfuW6KtyK"
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Comment", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.File", "File")
                        .WithMany("Comments")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("File");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.File", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.Folder", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Drive.Data.Entities.Models.User", "Owner")
                        .WithMany("Files")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Folder", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.User", "Owner")
                        .WithMany("Folders")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.Folder", "ParentFolder")
                        .WithMany("SubFolders")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Owner");

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.SharedItem", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.File", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Drive.Data.Entities.Models.Folder", "Folder")
                        .WithMany()
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Drive.Data.Entities.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Folder");

                    b.Navigation("Owner");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.File", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Folder", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("SubFolders");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.User", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Folders");
                });
#pragma warning restore 612, 618
        }
    }
}
