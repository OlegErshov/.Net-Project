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
    [Migration("20230519140523_Delete-HomeWork")]
    partial class DeleteHomeWork
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Plugin.Authorization.Student", b =>
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

                    b.Property<int?>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Plugin.Authorization.Teacher", b =>
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

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Plugin.Questions.GrammaQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GrammaTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sentence")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("rightAnswer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GrammaTaskId");

                    b.ToTable("GrammaQuestion");
                });

            modelBuilder.Entity("Plugin.Questions.InsertQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InsertTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("sentence")
                        .HasColumnType("TEXT");

                    b.Property<string>("word")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InsertTaskId");

                    b.ToTable("InsertQuestion");
                });

            modelBuilder.Entity("Plugin.Questions.SentenceQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SentenceTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Words")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SentenceTaskId");

                    b.ToTable("SentenceQuestion");
                });

            modelBuilder.Entity("Plugin.Questions.VocabluaryQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<int?>("VocabluaryTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("answer")
                        .HasColumnType("TEXT");

                    b.Property<string>("letters")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("VocabluaryTaskId");

                    b.ToTable("VocabluaryQuestion");
                });

            modelBuilder.Entity("Plugin.Tasks.GrammaTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StudentId")
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

                    b.Property<int?>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("words")
                        .IsRequired()
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

                    b.Property<int?>("StudentId")
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

                    b.Property<int?>("StudentId")
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
                    b.HasOne("Plugin.Tasks.GrammaTask", null)
                        .WithMany("questions")
                        .HasForeignKey("GrammaTaskId");
                });

            modelBuilder.Entity("Plugin.Questions.InsertQuestion", b =>
                {
                    b.HasOne("Plugin.Tasks.InsertTask", null)
                        .WithMany("questions")
                        .HasForeignKey("InsertTaskId");
                });

            modelBuilder.Entity("Plugin.Questions.SentenceQuestion", b =>
                {
                    b.HasOne("Plugin.Tasks.SentenceTask", null)
                        .WithMany("questions")
                        .HasForeignKey("SentenceTaskId");
                });

            modelBuilder.Entity("Plugin.Questions.VocabluaryQuestion", b =>
                {
                    b.HasOne("Plugin.Tasks.VocabluaryTask", null)
                        .WithMany("questions")
                        .HasForeignKey("VocabluaryTaskId");
                });

            modelBuilder.Entity("Plugin.Tasks.GrammaTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", null)
                        .WithMany("_GrammaList")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Plugin.Tasks.InsertTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", null)
                        .WithMany("_InsertList")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Plugin.Tasks.SentenceTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", null)
                        .WithMany("_SentenceList")
                        .HasForeignKey("StudentId");
                });

            modelBuilder.Entity("Plugin.Tasks.VocabluaryTask", b =>
                {
                    b.HasOne("Plugin.Authorization.Student", null)
                        .WithMany("_VocabluaryList")
                        .HasForeignKey("StudentId");
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