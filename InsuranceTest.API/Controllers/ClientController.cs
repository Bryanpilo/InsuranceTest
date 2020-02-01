using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientBL _clientBL;
        
        public ClientController(IClientBL clientBL)
        {
            _clientBL = clientBL;
        }

        //GET api/user/username
        [HttpGet]
        public IActionResult getAllClient()
        {
            var clients = _clientBL.getAllClients();

            if (clients != null)
                return Ok(clients);

            return StatusCode(204);
        }
        
    }
}