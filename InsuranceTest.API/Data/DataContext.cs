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

    }
}