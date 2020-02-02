using System.Collections.Generic;
using InsuranceTest.API.DTO.Client;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IInsuranceBL
    {
        IEnumerable<InsuranceDTO> getAllInsuranceByClientID(int Id);
        InsuranceDTO getAllInsuranceByInsuranceIdAndClientId(int Id, int clientId);
        bool addInsurance(InsuranceDTO insuranceDTO);
        bool updateInsurance(InsuranceDTO insuranceDTO);
        bool deleteInsurance(int Id);

    }
}