using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;
using InsuranceTest.API.DTO.Client;
using InsuranceTest.API.DTO.Insurance;
using InsuranceTest.API.Helper;

namespace InsuranceTest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceBL _insuranceBL;
        private readonly InsuranceValidations _insuranceValidations;

        public InsuranceController(IInsuranceBL insuranceBL,
                             InsuranceValidations insuranceValidations)
        {
            _insuranceBL = insuranceBL;
            _insuranceValidations = insuranceValidations;
        }

        [HttpPost("CreateInsurance")]
        public IActionResult CreateInsurance(InsuranceDTO insuranceDTO)
        {
            var values = false;
            if(_insuranceValidations.IsInsuranceHighRiskValidated(insuranceDTO.RiskId, insuranceDTO.Coverage))
            {
                values = _insuranceBL.addInsurance(insuranceDTO);
            }
            else
            {
                return BadRequest();
            }
                 

            if (values == false)
                return Unauthorized();


            return Ok(values);
        }

        [HttpPost("UpdateInsurance")]
        public IActionResult UpdateInsurance(InsuranceDTO insuranceDTO)
        {
            var values = false;
            if (_insuranceValidations.IsInsuranceHighRiskValidated(insuranceDTO.RiskId, insuranceDTO.Coverage))
            {
                values = _insuranceBL.updateInsurance(insuranceDTO);
            }
            else
            {
                return BadRequest();
            }


            if (values == false)
                return Unauthorized();


            return Ok(values);
        }


        [HttpPost("getInsurangeBYIds")]
        public IActionResult getInsurangeBYIds(getInsuranceByIds getInsuranceByIds)
        {
            var values = _insuranceBL.getAllInsuranceByInsuranceIdAndClientId(getInsuranceByIds.id, getInsuranceByIds.clientId);

            if (values == null)
                return StatusCode(204);


            return Ok(values);
        }

        [HttpPost]
        public IActionResult Post(getInsureByClientId getInsureByClientId)
        {
            var values = _insuranceBL.getAllInsuranceByClientID(getInsureByClientId.ClientId);

            if (values == null)
                return StatusCode(204);


            return Ok(values);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var values = _insuranceBL.deleteInsurance(id);

            if (values == false)
                return StatusCode(204);


            return Ok(values);
        }


    }
}