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

    }
}