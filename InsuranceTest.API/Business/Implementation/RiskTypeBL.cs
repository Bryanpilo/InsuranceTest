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
using System.Collections.Generic;
using InsuranceTest.API.DTO.RiskType;
using System.Linq;

namespace InsuranceTest.API.Business.Implementation
{
    public class RiskTypeBL : IRiskTypeBL
    {
        private readonly IRiskTypeRepository _riskTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RiskTypeBL(IUnitOfWork unitOfWork,
                             IMapper mapper, 
                             IConfiguration configuration,
                             IRiskTypeRepository riskTypeRepository)
        {
            _riskTypeRepository= riskTypeRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public IEnumerable<RiskTypeDTO> getAllRyskType()
        {
            var Clients=  _riskTypeRepository.GetAll();

            return _mapper.Map<IEnumerable<RiskTypeDTO>>(Clients.AsEnumerable());
        }
    }
}