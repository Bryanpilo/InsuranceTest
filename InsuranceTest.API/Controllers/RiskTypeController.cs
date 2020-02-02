using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RiskTypeController : ControllerBase
    {
        private readonly IRiskTypeBL _riskTypeBL;
        
        public RiskTypeController(IRiskTypeBL riskTypeBL)
        {
            _riskTypeBL = riskTypeBL;
        }

        [HttpGet("getAllRiskType")]
        public IActionResult getAllRiskType()
        {
            var riskTypes = _riskTypeBL.getAllRyskType();

            if (riskTypes != null)
                return Ok(riskTypes);

            return StatusCode(204);
        }
        
    }
}