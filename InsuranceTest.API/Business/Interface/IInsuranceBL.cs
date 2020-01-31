using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IInsuranceBL
    {
        void getAllInsuranceByClientID(int id);
        
        bool addInsurance();

        bool deleteInsurance();
    
    }
}