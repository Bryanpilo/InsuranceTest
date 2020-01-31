using System;
using System.Collections.Generic;

namespace InsuranceTest.API.Models
{
    public class InsuranceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Insurance_InsuranceType> InsuranInsurance_InsuranceTypeceTypes { get; set; }
    }
}