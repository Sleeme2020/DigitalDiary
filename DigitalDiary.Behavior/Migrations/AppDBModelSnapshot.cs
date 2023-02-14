﻿// <auto-generated />
using System;
using DigitalDiary.Behavior.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigitalDiary.Behavior.Migrations
{
    [DbContext(typeof(AppDB))]
    partial class AppDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("DigitalDiary.Model.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("DigitalDiary.Model.Human", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Human");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Human");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DigitalDiary.Model.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Val")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("WorkId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("DigitalDiary.Model.PairWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PairWorks");
                });

            modelBuilder.Entity("DigitalDiary.Model.Presence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClassWorkId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Val")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClassWorkId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Presences");
                });

            modelBuilder.Entity("DigitalDiary.Model.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("DigitalDiary.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DigitalDiary.Model.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Work");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Work");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DigitalDiary.Model.Parent", b =>
                {
                    b.HasBaseType("DigitalDiary.Model.Human");

                    b.HasDiscriminator().HasValue("Parent");
                });

            modelBuilder.Entity("DigitalDiary.Model.Student", b =>
                {
                    b.HasBaseType("DigitalDiary.Model.Human");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParentId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("DigitalDiary.Model.Teacher", b =>
                {
                    b.HasBaseType("DigitalDiary.Model.Human");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("DigitalDiary.Model.ClassWork", b =>
                {
                    b.HasBaseType("DigitalDiary.Model.Work");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PairWorkId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("PairWorkId");

                    b.HasIndex("SubjectId", "GroupId", "TeacherId", "Date", "PairWorkId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("ClassWork");
                });

            modelBuilder.Entity("DigitalDiary.Model.HomeWork", b =>
                {
                    b.HasBaseType("DigitalDiary.Model.Work");

                    b.Property<string>("About")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ClassWorkId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("TEXT");

                    b.HasIndex("ClassWorkId");

                    b.HasDiscriminator().HasValue("HomeWork");
                });

            modelBuilder.Entity("DigitalDiary.Model.Human", b =>
                {
                    b.HasOne("DigitalDiary.Model.User", "User")
                        .WithMany("Humans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalDiary.Model.Mark", b =>
                {
                    b.HasOne("DigitalDiary.Model.Student", "Student")
                        .WithMany("Marks")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalDiary.Model.Teacher", "Teacher")
                        .WithMany("Marks")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalDiary.Model.Work", "Work")
                        .WithMany("Marks")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("DigitalDiary.Model.Presence", b =>
                {
                    b.HasOne("DigitalDiary.Model.ClassWork", "ClassWork")
                        .WithMany("Presences")
                        .HasForeignKey("ClassWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalDiary.Model.Student", "Student")
                        .WithMany("Presences")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalDiary.Model.Teacher", "Teacher")
                        .WithMany("Presences")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassWork");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DigitalDiary.Model.Work", b =>
                {
                    b.HasOne("DigitalDiary.Model.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalDiary.Model.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalDiary.Model.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("DigitalDiary.Model.Student", b =>
                {
                    b.HasOne("DigitalDiary.Model.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalDiary.Model.Parent", "Parent")
                        .WithMany("Students")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DigitalDiary.Model.ClassWork", b =>
                {
                    b.HasOne("DigitalDiary.Model.PairWork", "PairWork")
                        .WithMany()
                        .HasForeignKey("PairWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PairWork");
                });

            modelBuilder.Entity("DigitalDiary.Model.HomeWork", b =>
                {
                    b.HasOne("DigitalDiary.Model.ClassWork", "ClassWork")
                        .WithMany("HomeWorks")
                        .HasForeignKey("ClassWorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassWork");
                });

            modelBuilder.Entity("DigitalDiary.Model.Group", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("DigitalDiary.Model.User", b =>
                {
                    b.Navigation("Humans");
                });

            modelBuilder.Entity("DigitalDiary.Model.Work", b =>
                {
                    b.Navigation("Marks");
                });

            modelBuilder.Entity("DigitalDiary.Model.Parent", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("DigitalDiary.Model.Student", b =>
                {
                    b.Navigation("Marks");

                    b.Navigation("Presences");
                });

            modelBuilder.Entity("DigitalDiary.Model.Teacher", b =>
                {
                    b.Navigation("Marks");

                    b.Navigation("Presences");
                });

            modelBuilder.Entity("DigitalDiary.Model.ClassWork", b =>
                {
                    b.Navigation("HomeWorks");

                    b.Navigation("Presences");
                });
#pragma warning restore 612, 618
        }
    }
}
