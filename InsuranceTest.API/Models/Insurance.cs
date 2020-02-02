using System;
using System.Collections.Generic;

namespace InsuranceTest.API.Models
{
    public class Insurance
    {
        public Insurance()
        {
            this.Insurances_InsuranceTypes = new HashSet<Insurance_InsuranceType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Coverage { get; set; }
        public int CoverageMonths { get; set; }
        public DateTime InitDate { get; set; }
        public decimal Price { get; set; }
        public int RiskTypeId { get; set; }
        public int ClientId { get; set; }

        public virtual RiskType RiskType { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<Insurance_InsuranceType> Insurances_InsuranceTypes { get; set; }

    }
}