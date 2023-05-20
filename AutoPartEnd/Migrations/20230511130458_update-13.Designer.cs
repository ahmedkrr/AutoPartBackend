﻿// <auto-generated />
using System;
using AutoPartEnd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoPartEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230511130458_update-13")]
    partial class update13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("SchemaEnd")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoPartEnd.Domain.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CarModel");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.CarType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("CarType");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("image");

                    b.HasKey("Id");

                    b.HasIndex("CategoryName")
                        .IsUnique();

                    b.ToTable("Category");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.CompanyProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("image");

                    b.Property<byte[]>("BackgroundImage")
                        .HasColumnType("image");

                    b.Property<string>("CompanyPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeactive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("CompanyProfile");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarModelId")
                        .HasColumnType("int");

                    b.Property<int?>("CarTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyProfileId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("image");

                    b.Property<bool>("IsUniversalItem")
                        .HasColumnType("bit");

                    b.Property<int?>("ManufactureYearId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SubCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarModelId");

                    b.HasIndex("CarTypeId");

                    b.HasIndex("CompanyProfileId");

                    b.HasIndex("ManufactureYearId");

                    b.HasIndex("SubCategoryId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.ManufactureYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("ManufactureYear");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.SubCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("image");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SubCategoryName")
                        .IsUnique();

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyProfileId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompanyOwner")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeactive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("CompanyProfileId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.CarType", b =>
                {
                    b.HasOne("AutoPartEnd.Domain.CarModel", "Model")
                        .WithMany("CarTypes")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.Item", b =>
                {
                    b.HasOne("AutoPartEnd.Domain.CarModel", "CarModel")
                        .WithMany()
                        .HasForeignKey("CarModelId");

                    b.HasOne("AutoPartEnd.Domain.CarType", "CarType")
                        .WithMany()
                        .HasForeignKey("CarTypeId");

                    b.HasOne("AutoPartEnd.Domain.CompanyProfile", "CompanyProfile")
                        .WithMany()
                        .HasForeignKey("CompanyProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPartEnd.Domain.ManufactureYear", "ManufactureYear")
                        .WithMany()
                        .HasForeignKey("ManufactureYearId");

                    b.HasOne("AutoPartEnd.Domain.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoPartEnd.Domain.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarModel");

                    b.Navigation("CarType");

                    b.Navigation("CompanyProfile");

                    b.Navigation("ManufactureYear");

                    b.Navigation("SubCategory");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.ManufactureYear", b =>
                {
                    b.HasOne("AutoPartEnd.Domain.CarType", "Types")
                        .WithMany("ManufactureYears")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Types");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.SubCategory", b =>
                {
                    b.HasOne("AutoPartEnd.Domain.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.UserProfile", b =>
                {
                    b.HasOne("AutoPartEnd.Domain.CompanyProfile", "CompanyProfile")
                        .WithMany("userProfiles")
                        .HasForeignKey("CompanyProfileId");

                    b.Navigation("CompanyProfile");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.CarModel", b =>
                {
                    b.Navigation("CarTypes");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.CarType", b =>
                {
                    b.Navigation("ManufactureYears");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("AutoPartEnd.Domain.CompanyProfile", b =>
                {
                    b.Navigation("userProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
