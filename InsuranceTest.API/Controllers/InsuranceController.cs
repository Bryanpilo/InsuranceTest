using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;

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
        
    }
}