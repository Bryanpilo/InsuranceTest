using System.Collections.Generic;
using InsuranceTest.API.DTO.Client;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IInsuranceBL
    {
        bool IsInsuranceHighRiskValidated(int RiskId, float Coverage);
        IEnumerable<InsuranceDTO> getAllInsuranceByClientID(int Id);

        bool addInsurance(InsuranceDTO insuranceDTO);

        bool deleteInsurance(int Id);

    }
}