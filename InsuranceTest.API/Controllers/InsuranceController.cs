using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;
using InsuranceTest.API.DTO.Client;

namespace InsuranceTest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceBL _insuranceBL;
        
        public InsuranceController(IInsuranceBL insuranceBL)
        {
            _insuranceBL = insuranceBL;
        }

         //POST api/user/login
        [AllowAnonymous]
        [HttpPost("CreateInsurance")]
        public IActionResult CreateInsurance(InsuranceDTO insuranceDTO)
        {
            var values = _insuranceBL.addInsurance(insuranceDTO);

            if (values == false)
                return Unauthorized();


            return Ok(values);
        }

        
    }
}