using System.Collections.Generic;
using InsuranceTest.API.DTO.InsuranceType;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IInsuranceTypeBL
    {
        IEnumerable<InsuranceTypeDTO> getAllInsuranceType();
    
    }
}