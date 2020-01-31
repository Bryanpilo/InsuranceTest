using System;
using System.Collections.Generic;

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

        public ICollection<InsuranceType> InsuranceTypes { get; set; }
        public RiskType RiskType { get; set; }
    }
}