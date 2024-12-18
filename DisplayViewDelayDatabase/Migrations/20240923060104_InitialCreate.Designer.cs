﻿// <auto-generated />
using System;
using DisplayViewDelayDatabase.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DisplayViewDelayDatabase.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240923060104_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("DisplayViewDelayDatabase.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(3);

                    b.Property<double>("Carbohydrates")
                        .HasColumnType("REAL")
                        .HasColumnOrder(5);

                    b.Property<double>("Fats")
                        .HasColumnType("REAL")
                        .HasColumnOrder(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasColumnOrder(2);

                    b.Property<double>("Proteins")
                        .HasColumnType("REAL")
                        .HasColumnOrder(6);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("DisplayViewDelayDatabase.Models.FoodSelection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<int>("FoodId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.Property<int>("Max")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(7);

                    b.Property<int>("Min")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(6);

                    b.Property<int>("OptimalAmount")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(8);

                    b.Property<int>("SavedMealId")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(2);

                    b.Property<int>("SortOrderIndex")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.HasIndex("SavedMealId");

                    b.ToTable("FoodSelections");
                });

            modelBuilder.Entity("DisplayViewDelayDatabase.Models.SavedMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("LastSavedDate")
                        .HasColumnType("TEXT")
                        .HasColumnOrder(12);

                    b.Property<int>("MacroNutrientRatio_MaxCalories")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(6);

                    b.Property<int>("MacroNutrientRatio_MaxCarbohydrates")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(4);

                    b.Property<int>("MacroNutrientRatio_MaxFats")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(5);

                    b.Property<int>("MacroNutrientRatio_MaxProteins")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(3);

                    b.Property<double>("MacroNutrientRatio_OptimalAmountCalories")
                        .HasColumnType("REAL")
                        .HasColumnOrder(10);

                    b.Property<double>("MacroNutrientRatio_OptimalAmountCarbohydrates")
                        .HasColumnType("REAL")
                        .HasColumnOrder(8);

                    b.Property<double>("MacroNutrientRatio_OptimalAmountFats")
                        .HasColumnType("REAL")
                        .HasColumnOrder(9);

                    b.Property<double>("MacroNutrientRatio_OptimalAmountProteins")
                        .HasColumnType("REAL")
                        .HasColumnOrder(7);

                    b.Property<bool>("ModifiedSinceLastSave")
                        .HasColumnType("INTEGER")
                        .HasColumnOrder(11);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT COLLATE NOCASE")
                        .HasColumnOrder(2);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SavedMeals");
                });

            modelBuilder.Entity("DisplayViewDelayDatabase.Models.FoodSelection", b =>
                {
                    b.HasOne("DisplayViewDelayDatabase.Models.Food", "FoodItem")
                        .WithMany("FoodSelections")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DisplayViewDelayDatabase.Models.SavedMeal", "SavedMealItem")
                        .WithMany("FoodSelections")
                        .HasForeignKey("SavedMealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodItem");

                    b.Navigation("SavedMealItem");
                });

            modelBuilder.Entity("DisplayViewDelayDatabase.Models.Food", b =>
                {
                    b.Navigation("FoodSelections");
                });

            modelBuilder.Entity("DisplayViewDelayDatabase.Models.SavedMeal", b =>
                {
                    b.Navigation("FoodSelections");
                });
#pragma warning restore 612, 618
        }
    }
}
