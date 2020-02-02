using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceTypeController : ControllerBase
    {
        private readonly IInsuranceTypeBL _insuranceTypeBL;
        
        public InsuranceTypeController(IInsuranceTypeBL insuranceTypeBL)
        {
            _insuranceTypeBL = insuranceTypeBL;
        }

        [HttpGet("getAllInsuranceType")]
        public IActionResult getAllInsuranceType()
        {
            var insuranceTypes = _insuranceTypeBL.getAllInsuranceType();

            if (insuranceTypes != null)
                return Ok(insuranceTypes);

            return StatusCode(204);
        }
        
    }
}