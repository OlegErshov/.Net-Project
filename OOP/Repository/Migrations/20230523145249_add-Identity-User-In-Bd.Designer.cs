﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository.Data;

#nullable disable

namespace Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230523145249_add-Identity-User-In-Bd")]
    partial class addIdentityUserInBd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IdentityUsers");
                });

            modelBuilder.Entity("Plugin.Authorization.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Plugin.Authorization.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Plugin.Questions.GrammaQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerVarients")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StringAnswer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("taskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("taskId");

                    b.ToTable("GrammaQuestion");
                });

            modelBuilder.Entity("Plugin.Questions.InsertQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sentence")
                        .HasColumnType("TEXT");

                    b.Property<string>("StringAnswer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("taskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("taskId");

                    b.ToTable("InsertQuestion");
                });

            modelBuilder.Entity("Plugin.Questions.SentenceQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StringAnswer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Words")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("taskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("taskId");

                    b.ToTable("SentenceQuestion");
                });

            modelBuilder.Entity("Plugin.Questions.VocabluaryQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("StringAnswer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("letters")
                        .HasColumnType("TEXT");

                    b.Property<int>("taskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("taskId");

                    b.ToTable("VocabluaryQuestion");
                });

            modelBuilder.Entity("Plugin.Tasks.GrammaTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("GrammaTasks");
                });

            modelBuilder.Entity("Plugin.Tasks.InsertTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("words")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("InsertTasks");
                });

            modelBuilder.Entity("Plugin.Tasks.SentenceTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("SentenceTasks");
                });

            modelBuilder.Entity("Plugin.Tasks.VocabluaryTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("VocabluaryTasks");
                });

            modelBuilder.Entity("Plugin.Authorization.Student", b =>
                {
                    b.HasOne("Plugin.Authorization.Teacher", null)
                        .WithMany("students")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Plugin.Questions.GrammaQuestion", b =>
                {
                    b.HasOne("Plugin.Tasks.GrammaTask", "task")
                        .WithMany("questions")
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("task");
                });

            modelBuilder.Entity("Plugin.Questions.InsertQuestion", b =>
                {
                    b.HasOne("Plugin.Tasks.InsertTask", "task")
                        .WithMany("questions")
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("task");
                });

            modelBuilder.Entity("Plugin.Questions.SentenceQuestion", b =>
                {
                    b.HasOne("Plugin.Tasks.SentenceTask", "task")
                        .WithMany("questions")
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("task");
                });

            modelBuilder.Entity("Plugin.Questions.VocabluaryQuestion", b =>
                {
                    b.HasOne("Plugin.Tasks.VocabluaryTask", "task")
                        .WithMany("questions")
                        .HasForeignKey("taskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("task");
                });

            modelBuilder.Entity("Plugin.Tasks.GrammaTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", "Student")
                        .WithMany("_GrammaList")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Plugin.Tasks.InsertTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", "Student")
                        .WithMany("_InsertList")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Plugin.Tasks.SentenceTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", "Student")
                        .WithMany("_SentenceList")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Plugin.Tasks.VocabluaryTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", "Student")
                        .WithMany("_VocabluaryList")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Plugin.Authorization.Student", b =>
                {
                    b.Navigation("_GrammaList");

                    b.Navigation("_InsertList");

                    b.Navigation("_SentenceList");

                    b.Navigation("_VocabluaryList");
                });

            modelBuilder.Entity("Plugin.Authorization.Teacher", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("Plugin.Tasks.GrammaTask", b =>
                {
                    b.Navigation("questions");
                });

            modelBuilder.Entity("Plugin.Tasks.InsertTask", b =>
                {
                    b.Navigation("questions");
                });

            modelBuilder.Entity("Plugin.Tasks.SentenceTask", b =>
                {
                    b.Navigation("questions");
                });

            modelBuilder.Entity("Plugin.Tasks.VocabluaryTask", b =>
                {
                    b.Navigation("questions");
                });
#pragma warning restore 612, 618
        }
    }
}
