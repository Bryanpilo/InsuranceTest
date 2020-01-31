using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL _userBL;
        public UserController(IUserBL userBL)
        {
            _userBL = userBL;
        }

        //POST api/user/login
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO userLoginDTO)
        {
            var values = _userBL.Login(userLoginDTO);

            if (values == null)
                return Unauthorized();


            return Ok(values);
        }

        //POST api/user/register
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO userRegisterDTO)
        {
            var user = _userBL.Register(userRegisterDTO);

            if (!user)
            {
                return StatusCode(409);
            }
            return StatusCode(201);
        }

        //GET api/user/username
        [HttpGet("{username}")]
        public IActionResult getUser(string username)
        {
            var user = _userBL.fullUser(username);

            if (username != null)
                return Ok(user);

            return StatusCode(204);
        }
    }
}