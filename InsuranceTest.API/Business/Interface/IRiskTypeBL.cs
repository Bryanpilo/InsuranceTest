using System.Collections.Generic;
using InsuranceTest.API.DTO.RiskType;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IRiskTypeBL
    {
         IEnumerable<RiskTypeDTO> getAllRyskType();
    
    }
}