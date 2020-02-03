using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using InsuranceTest.API.DTO.InsuranceType;
using InsuranceTest.API.DTO.RiskType;
using InsuranceTest.API.Models;

namespace InsuranceTest.API.DTO.Client
{
    public class InsuranceDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float Coverage { get; set; }
        [Required]
        public int CoverageMonths { get; set; }
        [Required]
        public DateTime InitDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int RiskId { get; set; }
        [Required]
        public int ClientId { get; set; }
        public List<InsuranceTypeDTO> insuranceTypeDTOs { get; set; }


    }
}