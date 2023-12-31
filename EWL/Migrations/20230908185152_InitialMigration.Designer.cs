﻿// <auto-generated />
using EWL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EWL.Migrations
{
    [DbContext(typeof(VocabularyContext))]
    [Migration("20230908185152_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("Eng_Flash_Cards_Learner.AllWord", b =>
                {
                    b.Property<long>("WordId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("WordID");

                    b.Property<string>("EngWord")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Repetition")
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

                    b.Property<long>("CanBeDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("CreatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<long>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("DeletedAt")
                        .IsRequired()
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

                    b.Property<long>("WasLaunched")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WordAddingMode")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WordCountToLearn")
                        .HasColumnType("INTEGER");

                    b.HasKey("SettingsId");

                    b.HasIndex("CurrentCategoryId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Eng_Flash_Cards_Learner.WordCategory", b =>
                {
                    b.Property<byte[]>("AddedAt")
                        .IsRequired()
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
