﻿// <auto-generated />
using System;
using KUSYSDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KUSYSDemo.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KUSYSDemo.Models.Entity.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = "CSI101",
                            CourseName = "Introduction to Computer Science"
                        },
                        new
                        {
                            CourseId = "CSI102",
                            CourseName = "Algorithms"
                        },
                        new
                        {
                            CourseId = "MAT101",
                            CourseName = "Calculus"
                        },
                        new
                        {
                            CourseId = "PHY101",
                            CourseName = "Physics"
                        });
                });

            modelBuilder.Entity("KUSYSDemo.Models.Entity.CourseStudent", b =>
                {
                    b.Property<int>("CourseStudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseStudentId"), 1L, 1);

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CourseStudentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("KUSYSDemo.Models.Entity.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "User"
                        });
                });

            modelBuilder.Entity("KUSYSDemo.Models.Entity.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoginUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("CourseId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            BirthDate = new DateTime(1998, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Deneme1",
                            LastName = "Öğrenci1",
                            LoginPassword = "111",
                            LoginUserName = "Admin1",
                            RoleId = 1
                        },
                        new
                        {
                            StudentId = 2,
                            BirthDate = new DateTime(1999, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Deneme2",
                            LastName = "Öğrenci2",
                            LoginPassword = "111",
                            LoginUserName = "Admin2",
                            RoleId = 1
                        },
                        new
                        {
                            StudentId = 3,
                            BirthDate = new DateTime(1994, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Deneme3",
                            LastName = "Öğrenci3",
                            LoginPassword = "111",
                            LoginUserName = "Admin3",
                            RoleId = 1
                        },
                        new
                        {
                            StudentId = 4,
                            BirthDate = new DateTime(1995, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Deneme4",
                            LastName = "Öğrenci4",
                            LoginPassword = "111",
                            LoginUserName = "User3",
                            RoleId = 2
                        },
                        new
                        {
                            StudentId = 5,
                            BirthDate = new DateTime(1996, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Deneme5",
                            LastName = "Öğrenci5",
                            LoginPassword = "111",
                            LoginUserName = "User4",
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("KUSYSDemo.Models.Entity.CourseStudent", b =>
                {
                    b.HasOne("KUSYSDemo.Models.Entity.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KUSYSDemo.Models.Entity.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("KUSYSDemo.Models.Entity.Student", b =>
                {
                    b.HasOne("KUSYSDemo.Models.Entity.Course", null)
                        .WithMany("Students")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("KUSYSDemo.Models.Entity.Course", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("KUSYSDemo.Models.Entity.Student", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}