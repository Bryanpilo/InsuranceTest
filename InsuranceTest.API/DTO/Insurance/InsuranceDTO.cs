using System;
using System.Collections.Generic;
using InsuranceTest.API.DTO.InsuranceType;
using InsuranceTest.API.DTO.RiskType;
using InsuranceTest.API.Models;

namespace InsuranceTest.API.DTO.Client
{
    public class InsuranceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Coverage { get; set; }
        public int CoverageMonths { get; set; }
        public DateTime InitDate { get; set; }
        public decimal Price { get; set; }

        public RiskTypeDTO RiskType { get; set; }

        public ICollection<InsuranceTypeDTO> InsuranceTypes { get; set; }
    }
}