using System.Collections.Generic;

namespace InsuranceTest.API.Models
{
    public class Insurance_InsuranceType
    {
        public Insurance_InsuranceType()
        {
        }

        public int Id { get; set; }
        public int InsuranceId { get; set; }
        public virtual Insurance Insurance { get; set; }
        public int InsuranceTypeId { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }

    }
}