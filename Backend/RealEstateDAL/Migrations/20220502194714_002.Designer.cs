﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstateDAL.Context;

#nullable disable

namespace RealEstateDAL.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    [Migration("20220502194714_002")]
    partial class _002
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RealEstateDAL.Entities.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PersonalID")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SerieNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Validity")
                        .HasColumnType("Date");

                    b.HasKey("ID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.ConfigurationItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ConfigurationsItems");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.ConfigurationOption", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ConfigurationItemId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ConfigurationItemId")
                        .IsUnique();

                    b.ToTable("ConfigurationsOptions");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Contract", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<int>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<int?>("PropertyID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DeveloperID");

                    b.HasIndex("PropertyID")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Developer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("ApartmentNo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("BuildingsNo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("DeveloperID")
                        .HasColumnType("int");

                    b.Property<int?>("HouseNo")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.HasIndex("DeveloperID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Property", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BuildingNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("IdentityNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LotSqm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<string>("PropertySqm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoomNo")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.PropertyConfiguration", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ContractID")
                        .HasColumnType("int");

                    b.Property<string>("FormNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("ContractID")
                        .IsUnique();

                    b.ToTable("PropertiesConfigurations");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.PropertyConfigurationItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("ConfigurationItemID")
                        .HasColumnType("int");

                    b.Property<int>("ConfigurationOptionID")
                        .HasColumnType("int");

                    b.Property<int>("PropertyConfigurationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ConfigurationItemID")
                        .IsUnique();

                    b.HasIndex("ConfigurationOptionID")
                        .IsUnique();

                    b.HasIndex("PropertyConfigurationID")
                        .IsUnique();

                    b.ToTable("PropertiesConfigurationsItems");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Client", b =>
                {
                    b.HasOne("RealEstateDAL.Entities.Developer", "Developer")
                        .WithMany("Client")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.ConfigurationOption", b =>
                {
                    b.HasOne("RealEstateDAL.Entities.ConfigurationItem", "ConfigurationItem")
                        .WithOne("ConfigurationOption")
                        .HasForeignKey("RealEstateDAL.Entities.ConfigurationOption", "ConfigurationItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConfigurationItem");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Contract", b =>
                {
                    b.HasOne("RealEstateDAL.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateDAL.Entities.Developer", "Developer")
                        .WithMany("Contracts")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateDAL.Entities.Property", "Property")
                        .WithOne("Contract")
                        .HasForeignKey("RealEstateDAL.Entities.Contract", "PropertyID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Developer");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Project", b =>
                {
                    b.HasOne("RealEstateDAL.Entities.Developer", "Developer")
                        .WithMany("Projects")
                        .HasForeignKey("DeveloperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Property", b =>
                {
                    b.HasOne("RealEstateDAL.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.PropertyConfiguration", b =>
                {
                    b.HasOne("RealEstateDAL.Entities.Contract", "Contract")
                        .WithOne("Configuration")
                        .HasForeignKey("RealEstateDAL.Entities.PropertyConfiguration", "ContractID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.PropertyConfigurationItems", b =>
                {
                    b.HasOne("RealEstateDAL.Entities.ConfigurationItem", "ConfigurationItem")
                        .WithOne("PropertyConfigurationItems")
                        .HasForeignKey("RealEstateDAL.Entities.PropertyConfigurationItems", "ConfigurationItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateDAL.Entities.ConfigurationOption", "ConfigurationOption")
                        .WithOne("PropertyConfigurationItems")
                        .HasForeignKey("RealEstateDAL.Entities.PropertyConfigurationItems", "ConfigurationOptionID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RealEstateDAL.Entities.PropertyConfiguration", "PropertyConfiguration")
                        .WithOne("PropertyConfigurationItems")
                        .HasForeignKey("RealEstateDAL.Entities.PropertyConfigurationItems", "PropertyConfigurationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConfigurationItem");

                    b.Navigation("ConfigurationOption");

                    b.Navigation("PropertyConfiguration");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.ConfigurationItem", b =>
                {
                    b.Navigation("ConfigurationOption")
                        .IsRequired();

                    b.Navigation("PropertyConfigurationItems")
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateDAL.Entities.ConfigurationOption", b =>
                {
                    b.Navigation("PropertyConfigurationItems")
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Contract", b =>
                {
                    b.Navigation("Configuration")
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Developer", b =>
                {
                    b.Navigation("Client");

                    b.Navigation("Contracts");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("RealEstateDAL.Entities.Property", b =>
                {
                    b.Navigation("Contract")
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateDAL.Entities.PropertyConfiguration", b =>
                {
                    b.Navigation("PropertyConfigurationItems")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}