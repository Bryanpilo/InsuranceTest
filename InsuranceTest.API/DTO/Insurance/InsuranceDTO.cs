using System;
using System.Collections.Generic;
using InsuranceTest.API.DTO.InsuranceType;
using InsuranceTest.API.DTO.RiskType;
using InsuranceTest.API.Models;

namespace InsuranceTest.API.DTO.Client
{
    public class InsuranceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Coverage { get; set; }
        public int CoverageMonths { get; set; }
        public DateTime InitDate { get; set; }
        public decimal Price { get; set; }
        public string RiskName { get; set; }


    }
}