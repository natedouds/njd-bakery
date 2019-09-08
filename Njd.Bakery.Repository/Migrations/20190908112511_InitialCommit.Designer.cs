﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Njd.Bakery.Repository;

namespace Njd.Bakery.Repository.Migrations
{
    [DbContext(typeof(BakeryContext))]
    [Migration("20190908112511_InitialCommit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Njd.Bakery.Repository.EfModels.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Njd.Bakery.Repository.EfModels.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanBeDairyFree");

                    b.Property<bool>("CanBeEggFree");

                    b.Property<bool>("CanBeGlutenFree");

                    b.Property<bool>("CanBeGrainFree");

                    b.Property<bool>("CanBeNutFree");

                    b.Property<bool>("CanBeRefinedSugarFree");

                    b.Property<bool>("CanBeVegan");

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("ClassificationId");

                    b.Property<bool>("DairyFree");

                    b.Property<int>("DefaultNumberOfServings");

                    b.Property<bool>("EggFree");

                    b.Property<bool>("GlutenFree");

                    b.Property<bool>("GrainFree");

                    b.Property<string>("Name");

                    b.Property<bool>("NutFree");

                    b.Property<int?>("ParentId");

                    b.Property<string>("ParentId1");

                    b.Property<bool>("RefinedSugarFree");

                    b.Property<string>("Sku");

                    b.Property<decimal>("TotalBatchCalories")
                        .HasColumnType("decimal(9, 4)");

                    b.Property<decimal>("TotalBatchCarbs")
                        .HasColumnType("decimal(9, 4)");

                    b.Property<decimal>("TotalBatchFat")
                        .HasColumnType("decimal(9, 4)");

                    b.Property<decimal>("TotalBatchFiber")
                        .HasColumnType("decimal(9, 4)");

                    b.Property<decimal>("TotalBatchProtein")
                        .HasColumnType("decimal(9, 4)");

                    b.Property<decimal>("TotalBatchSugar")
                        .HasColumnType("decimal(9, 4)");

                    b.Property<bool>("Vegan");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ClassificationId");

                    b.HasIndex("ParentId1");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Njd.Bakery.Repository.EfModels.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Snack Bars"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cakes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Breads"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cookies"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Dessert Bars"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Misc"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Muffins"
                        });
                });

            modelBuilder.Entity("Njd.Bakery.Repository.EfModels.ProductClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProductClassifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Simple Dessert"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Involved Dessert"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Snack"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bread"
                        });
                });

            modelBuilder.Entity("Njd.Bakery.Repository.EfModels.ProductIngredient", b =>
                {
                    b.Property<string>("ProductId");

                    b.Property<int>("IngredientId");

                    b.HasKey("ProductId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("ProductIngredients");
                });

            modelBuilder.Entity("Njd.Bakery.Repository.EfModels.Product", b =>
                {
                    b.HasOne("Njd.Bakery.Repository.EfModels.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Njd.Bakery.Repository.EfModels.ProductClassification", "Classification")
                        .WithMany()
                        .HasForeignKey("ClassificationId");

                    b.HasOne("Njd.Bakery.Repository.EfModels.Product", "Parent")
                        .WithMany("ProductVariations")
                        .HasForeignKey("ParentId1");
                });

            modelBuilder.Entity("Njd.Bakery.Repository.EfModels.ProductIngredient", b =>
                {
                    b.HasOne("Njd.Bakery.Repository.EfModels.Ingredient", "Ingredient")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Njd.Bakery.Repository.EfModels.Product", "Product")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}