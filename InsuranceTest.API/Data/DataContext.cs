using System;
using InsuranceTest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InsuranceTest.API.Data
{
    public class DataContext : DbContext
    {

        //this is our constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //this will be ours tables
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<RiskType> RiskTypes { get; set; }

        public DbSet<Insurance_InsuranceType> Insurances_InsuranceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Insurance>().HasData(
                    new[]{
                        new Insurance
                        {
                            Id= 1,
                            Name= "Poliza",
                            Description= "Poliza 1",
                            Coverage= 30,
                            CoverageMonths= 4,
                            InitDate=new DateTime(2017, 4, 22),
                            Price= 1000,
                            RiskTypeId= 1,
                            ClientId= 1
                        },
                        new Insurance
                        {
                            Id= 2,
                            Name= "Poliza 2",
                            Description= "Poliza 2",
                            Coverage= 60,
                            CoverageMonths= 1,
                            InitDate=new DateTime(2017, 4, 22),
                            Price= 2000,
                            RiskTypeId= 3,
                            ClientId= 4
                        },
                        new Insurance
                        {
                            Id= 3,
                            Name= "Poliza 3",
                            Description= "Poliza 3",
                            Coverage= 10,
                            CoverageMonths= 2,
                            InitDate=new DateTime(2017, 4, 22),
                            Price= 5000,
                            RiskTypeId= 4,
                            ClientId= 2
                        },
                        new Insurance
                        {
                            Id= 4,
                            Name= "Poliza 4",
                            Description= "Poliza 4",
                            Coverage= 100,
                            CoverageMonths= 3,
                            InitDate=new DateTime(2017, 4, 22),
                            Price= 10000,
                            RiskTypeId= 3,
                            ClientId= 4
                        },
                        new Insurance
                        {
                            Id= 5,
                            Name= "Poliza 5",
                            Description= "Poliza 5",
                            Coverage= 50,
                            CoverageMonths= 7,
                            InitDate=new DateTime(2017, 4, 22),
                            Price= 2000,
                            RiskTypeId= 4,
                            ClientId= 4
                        },
                        new Insurance
                        {
                            Id= 6,
                            Name= "Poliza 6",
                            Description= "Poliza 6",
                            Coverage= 25,
                            CoverageMonths= 9,
                            InitDate=new DateTime(2017, 4, 22),
                            Price= 5000,
                            RiskTypeId= 3,
                            ClientId= 2
                        }
                    }
                );

            modelBuilder.Entity<InsuranceType>().HasData(
                    new[]{
                        new InsuranceType
                        {
                             Id= 1,
                            Name = "Terremoto"
                        },
                        new InsuranceType
                         {
                              Id= 2,
                             Name = "Incendio"
                         },
                        new InsuranceType
                         {
                              Id= 3,
                             Name = "Robo"
                         },
                        new InsuranceType
                         {
                              Id= 4,
                             Name = "Pérdida"
                         }
                    }
                );

            modelBuilder.Entity<Insurance_InsuranceType>().HasData(
                    new[]
                    {
                        new Insurance_InsuranceType
                        {
                            Id= 1,
                            InsuranceId= 1,
                            InsuranceTypeId= 2
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 2,
                            InsuranceId= 1,
                            InsuranceTypeId= 1
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 3,
                            InsuranceId= 2,
                            InsuranceTypeId= 3
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 4,
                            InsuranceId= 3,
                            InsuranceTypeId= 4
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 5,
                            InsuranceId= 3,
                            InsuranceTypeId= 1
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 6,
                            InsuranceId= 3,
                            InsuranceTypeId= 2
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 7,
                            InsuranceId= 4,
                            InsuranceTypeId= 2
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 8,
                            InsuranceId= 4,
                            InsuranceTypeId= 1
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 9,
                            InsuranceId= 5,
                            InsuranceTypeId= 1
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 10,
                            InsuranceId= 5,
                            InsuranceTypeId= 2
                        },
                        new Insurance_InsuranceType
                        {
                            Id= 11,
                            InsuranceId= 5,
                            InsuranceTypeId= 4
                        }
                    }
                );

            modelBuilder.Entity<Client>().HasData(
                    new[]{
                        new Client
                        {
                            Id= 1,
                            FullName = "Bryan Espinoza López",
                            InitDate = new DateTime(2017, 1, 18),
                            Charge = "Software developer",
                            Salary = 1000
                        },
                        new Client
                        {
                            Id= 2,
                            FullName = "Josue Jara Sanchez",
                            InitDate = new DateTime(2017, 4, 22),
                            Charge = "Project Manager",
                            Salary = 3000
                        },
                        new Client
                        {
                            Id= 3,
                            FullName = "Denia Barboza Grajal",
                            InitDate = new DateTime(2020, 1, 18),
                            Charge = "Software developer",
                            Salary = 1000
                        },
                        new Client
                        {
                            Id= 4,
                            FullName = "Ivannia Lacayo Varquero",
                            InitDate = new DateTime(2015, 5, 12),
                            Charge = "Assistan Manager",
                            Salary = 1500
                        }
                    }
                );

                modelBuilder.Entity<RiskType>().HasData(
                    new[]{
                         new RiskType
                        {
                             Id= 1,
                            Risk = "Bajo"
                        },
                         new RiskType
                         {
                              Id= 2,
                             Risk = "Medio"
                         },
                         new RiskType
                         {
                              Id= 3,
                             Risk = "Medio-alto"
                         },
                         new RiskType
                         {
                              Id= 4,
                             Risk = "Alto"
                         }
                    }
                );

        }

    }
}
