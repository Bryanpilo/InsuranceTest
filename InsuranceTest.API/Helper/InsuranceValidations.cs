namespace InsuranceTest.API.Helper
{
    public class InsuranceValidations
    {
        public bool IsInsuranceHighRiskValidated(int RiskId, float Coverage)
        {
            return RiskId == 4 && Coverage > 50 ? false : true;
        }
    }
}