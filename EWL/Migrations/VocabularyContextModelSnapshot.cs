﻿// <auto-generated />
using System;
using Eng_Flash_Cards_Learner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eng_Flash_Cards_Learner.Migrations
{
    [DbContext(typeof(VocabularyContext))]
    partial class VocabularyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Eng_Flash_Cards_Learner.AllWord", b =>
                {
                    b.Property<long>("WordId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("WordID");

                    b.Property<int>("Difficulty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EngWord")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Repetition")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UaTranslation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WordId");

                    b.ToTable("AllWords");
                });

            modelBuilder.Entity("Eng_Flash_Cards_Learner.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CategoryID");

                    b.Property<bool>("CanBeDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeletedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("'2000-01-01 00:00:00'");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Eng_Flash_Cards_Learner.Setting", b =>
                {
                    b.Property<long>("SettingsId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("SettingsID");

                    b.Property<long>("CurrentCategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CurrentCategoryID");

                    b.Property<bool>("WasLaunched")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WordAddingMode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WordCountToLearn")
                        .HasColumnType("INTEGER");

                    b.HasKey("SettingsId");

                    b.HasIndex("CurrentCategoryId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Eng_Flash_Cards_Learner.WordCategory", b =>
                {
                    b.Property<DateTime>("AddedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<long>("CategoryId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CategoryID");

                    b.Property<long>("WordId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("WordID");

                    b.HasIndex("CategoryId");

                    b.HasIndex("WordId");

                    b.ToTable("WordCategories");
                });

            modelBuilder.Entity("Eng_Flash_Cards_Learner.Setting", b =>
                {
                    b.HasOne("Eng_Flash_Cards_Learner.Category", "CurrentCategory")
                        .WithMany("Settings")
                        .HasForeignKey("CurrentCategoryId")
                        .IsRequired();

                    b.Navigation("CurrentCategory");
                });

            modelBuilder.Entity("Eng_Flash_Cards_Learner.WordCategory", b =>
                {
                    b.HasOne("Eng_Flash_Cards_Learner.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .IsRequired();

                    b.HasOne("Eng_Flash_Cards_Learner.AllWord", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Eng_Flash_Cards_Learner.Category", b =>
                {
                    b.Navigation("Settings");
                });
#pragma warning restore 612, 618
        }
    }
}
