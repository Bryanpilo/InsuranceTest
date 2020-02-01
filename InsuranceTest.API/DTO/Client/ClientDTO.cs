using System;
using System.Collections.Generic;
using InsuranceTest.API.Models;

namespace InsuranceTest.API.DTO.Client
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }    
        public DateTime InitDate { get; set; }
        public decimal Salary { get; set; }
        public string Charge { get; set; }
    }
}