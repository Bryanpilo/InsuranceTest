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
    [Migration("20200202230910_SeedUserV3")]
    partial class SeedUserV3
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

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<float>("Coverage")
                        .HasColumnType("real");

                    b.Property<int>("CoverageMonths")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RiskTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("RiskTypeId");

                    b.ToTable("Insurances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            Coverage = 30f,
                            CoverageMonths = 4,
                            Description = "Poliza 1",
                            InitDate = new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Poliza",
                            Price = 1000m,
                            RiskTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 4,
                            Coverage = 60f,
                            CoverageMonths = 1,
                            Description = "Poliza 2",
                            InitDate = new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Poliza 2",
                            Price = 2000m,
                            RiskTypeId = 3
                        },
                        new
                        {
                            Id = 3,
                            ClientId = 2,
                            Coverage = 10f,
                            CoverageMonths = 2,
                            Description = "Poliza 3",
                            InitDate = new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Poliza 3",
                            Price = 5000m,
                            RiskTypeId = 4
                        },
                        new
                        {
                            Id = 4,
                            ClientId = 4,
                            Coverage = 100f,
                            CoverageMonths = 3,
                            Description = "Poliza 4",
                            InitDate = new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Poliza 4",
                            Price = 10000m,
                            RiskTypeId = 3
                        },
                        new
                        {
                            Id = 5,
                            ClientId = 4,
                            Coverage = 50f,
                            CoverageMonths = 7,
                            Description = "Poliza 5",
                            InitDate = new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Poliza 5",
                            Price = 2000m,
                            RiskTypeId = 4
                        },
                        new
                        {
                            Id = 6,
                            ClientId = 2,
                            Coverage = 25f,
                            CoverageMonths = 9,
                            Description = "Poliza 6",
                            InitDate = new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Poliza 6",
                            Price = 5000m,
                            RiskTypeId = 3
                        });
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

            modelBuilder.Entity("InsuranceTest.API.Models.Insurance_InsuranceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InsuranceId")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InsuranceId");

                    b.HasIndex("InsuranceTypeId");

                    b.ToTable("Insurances_InsuranceTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InsuranceId = 1,
                            InsuranceTypeId = 2
                        },
                        new
                        {
                            Id = 2,
                            InsuranceId = 1,
                            InsuranceTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            InsuranceId = 2,
                            InsuranceTypeId = 3
                        },
                        new
                        {
                            Id = 4,
                            InsuranceId = 3,
                            InsuranceTypeId = 4
                        },
                        new
                        {
                            Id = 5,
                            InsuranceId = 3,
                            InsuranceTypeId = 1
                        },
                        new
                        {
                            Id = 6,
                            InsuranceId = 3,
                            InsuranceTypeId = 2
                        },
                        new
                        {
                            Id = 7,
                            InsuranceId = 4,
                            InsuranceTypeId = 2
                        },
                        new
                        {
                            Id = 8,
                            InsuranceId = 4,
                            InsuranceTypeId = 1
                        },
                        new
                        {
                            Id = 9,
                            InsuranceId = 5,
                            InsuranceTypeId = 1
                        },
                        new
                        {
                            Id = 10,
                            InsuranceId = 5,
                            InsuranceTypeId = 2
                        },
                        new
                        {
                            Id = 11,
                            InsuranceId = 5,
                            InsuranceTypeId = 4
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

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "admin123",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "admin123",
                            Username = "Josue"
                        });
                });

            modelBuilder.Entity("InsuranceTest.API.Models.Insurance", b =>
                {
                    b.HasOne("InsuranceTest.API.Models.Client", "Client")
                        .WithMany("Insurances")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceTest.API.Models.RiskType", "RiskType")
                        .WithMany("Insurances")
                        .HasForeignKey("RiskTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceTest.API.Models.Insurance_InsuranceType", b =>
                {
                    b.HasOne("InsuranceTest.API.Models.Insurance", "Insurance")
                        .WithMany("Insurances_InsuranceTypes")
                        .HasForeignKey("InsuranceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceTest.API.Models.InsuranceType", "InsuranceType")
                        .WithMany("Insurances_InsuranceTypes")
                        .HasForeignKey("InsuranceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
