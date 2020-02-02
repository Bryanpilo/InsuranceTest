using System.Collections.Generic;

namespace InsuranceTest.API.Models
{
    public class RiskType
    {
        public RiskType()
        {
            this.Insurances = new HashSet<Insurance>();
        }

        public int Id { get; set; }
        public string Risk { get; set; }

        public virtual ICollection<Insurance> Insurances { get; set; }

    }
}