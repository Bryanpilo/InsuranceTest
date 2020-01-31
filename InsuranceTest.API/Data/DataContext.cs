using Microsoft.EntityFrameworkCore;

namespace InsuranceTest.API.Data
{
    public class DataContext : DbContext
    {

        //this is our constructor
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}