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
        }

    }
}
