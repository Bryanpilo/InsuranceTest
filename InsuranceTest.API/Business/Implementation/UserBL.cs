using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.DTO.User;
using InsuranceTest.API.Models;
using InsuranceTest.API.Repository.Interface;

namespace InsuranceTest.API.Business.Implementation
{
    public class UserBL : IUserBL
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserBL(IUnitOfWork unitOfWork,
                             IMapper mapper, 
                             IConfiguration configuration,
                             IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public UserDTO Login(UserLoginDTO userLoginDTO)
        {
            var user = _userRepository.GetSingle(x => x.Username == userLoginDTO.username.ToLower() && x.Password==userLoginDTO.password.ToLower());

            if (user == null)
            {
                return null;
            }

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super Secret Project"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(TokenDescriptor);
            // UserDTO userDTO= new UserDTO();
            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            userDTO.Token = tokenHandler.WriteToken(token);
            // var va= _mapper.Map<IEnumerable<UserDTO>>(List);

            return userDTO;
        }

        public FullUserDTO fullUser(string username)
        {
            var user = _userRepository.GetSingle(x => x.Username == username);

            FullUserDTO fullUser= _mapper.Map<FullUserDTO>(user);

            return fullUser;
        }
    }
}