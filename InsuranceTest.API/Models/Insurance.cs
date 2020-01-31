using System;

namespace InsuranceTest.API.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoverageMonths { get; set; }
        public DateTime InitDate { get; set; }
        public decimal Price { get; set; }
    }
}