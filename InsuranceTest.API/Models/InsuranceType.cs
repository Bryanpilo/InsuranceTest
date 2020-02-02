using System;
using System.Collections.Generic;

namespace InsuranceTest.API.Models
{
    public class InsuranceType
    {
        public InsuranceType()
        {
            this.Insurances_InsuranceTypes = new HashSet<Insurance_InsuranceType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Insurance_InsuranceType> Insurances_InsuranceTypes { get; set; }
    }
}