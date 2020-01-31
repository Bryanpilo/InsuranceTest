﻿// <auto-generated />
using System;
using InsuranceTest.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsuranceTest.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200131204015_seedingData")]
    partial class seedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InsuranceTest.API.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Charge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InitDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Charge = "Software developer",
                            FullName = "Bryan Espinoza López",
                            InitDate = new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 1000m
                        },
                        new
                        {
                            Id = 2,
                            Charge = "Project Manager",
                            FullName = "Josue Jara Sanchez",
                            InitDate = new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 3000m
                        },
                        new
                        {
                            Id = 3,
                            Charge = "Software developer",
                            FullName = "Denia Barboza Grajal",
                            InitDate = new DateTime(2020, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 1000m
                        },
                        new
                        {
                            Id = 4,
                            Charge = "Assistan Manager",
                            FullName = "Ivannia Lacayo Varquero",
                            InitDate = new DateTime(2015, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = 1500m
                        });
                });

            modelBuilder.Entity("InsuranceTest.API.Models.Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<float>("Coverage")
                        .HasColumnType("real");

                    b.Property<int>("CoverageMonths")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InitDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InsuranceTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RiskTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("InsuranceTypeId");

                    b.HasIndex("RiskTypeId");

                    b.ToTable("Insurances");
                });

            modelBuilder.Entity("InsuranceTest.API.Models.InsuranceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InsuranceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Terremoto"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Incendio"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Robo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pérdida"
                        });
                });

            modelBuilder.Entity("InsuranceTest.API.Models.RiskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Risk")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RiskTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Risk = "Bajo"
                        },
                        new
                        {
                            Id = 2,
                            Risk = "Medio"
                        },
                        new
                        {
                            Id = 3,
                            Risk = "Medio-alto"
                        },
                        new
                        {
                            Id = 4,
                            Risk = "Alto"
                        });
                });

            modelBuilder.Entity("InsuranceTest.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InsuranceTest.API.Models.Insurance", b =>
                {
                    b.HasOne("InsuranceTest.API.Models.Client", null)
                        .WithMany("Insurances")
                        .HasForeignKey("ClientId");

                    b.HasOne("InsuranceTest.API.Models.InsuranceType", null)
                        .WithMany("InsuranceTypes")
                        .HasForeignKey("InsuranceTypeId");

                    b.HasOne("InsuranceTest.API.Models.RiskType", "RiskType")
                        .WithMany()
                        .HasForeignKey("RiskTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
