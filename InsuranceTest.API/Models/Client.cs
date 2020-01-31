using System;

namespace InsuranceTest.API.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }    
        public DateTime InitDate { get; set; }
        public decimal Salary { get; set; }
        public string Change { get; set; }
    }
}