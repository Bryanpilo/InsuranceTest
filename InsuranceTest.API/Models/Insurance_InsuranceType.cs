namespace InsuranceTest.API.Models
{
    public class Insurance_InsuranceType
    {
        public int Id { get; set; }
        public int InsuranceId { get; set; }
        public Insurance Insurance { get; set; }
        public int InsuranceTypeId { get; set; }
        public InsuranceType InsuranceType { get; set; }
    }
}