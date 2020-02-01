using System;
using System.Collections.Generic;

namespace InsuranceTest.API.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Coverage { get; set; }
        public int CoverageMonths { get; set; }
        public DateTime InitDate { get; set; }
        public decimal Price { get; set; }
        public int RiskTypeId { get; set; }
        public int ClientId { get; set; }

        public RiskType RiskType { get; set; }
        public Client Client { get; set; }

        public ICollection<Insurance_InsuranceType> InsuranInsurance_InsuranceTypeceTypes { get; set; }
    }
}