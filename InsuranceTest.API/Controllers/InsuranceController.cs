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

        [HttpPost("CreateInsurance")]
        public IActionResult CreateInsurance(InsuranceDTO insuranceDTO)
        {
            var values = _insuranceBL.addInsurance(insuranceDTO);

            if (values == false)
                return Unauthorized();


            return Ok(values);
        }

        [HttpPost]
        public IActionResult Post(int id)
        {
            var values = _insuranceBL.getAllInsuranceByClientID(id);

            if (values == null)
                return StatusCode(204);


            return Ok(values);
        }

        
    }
}