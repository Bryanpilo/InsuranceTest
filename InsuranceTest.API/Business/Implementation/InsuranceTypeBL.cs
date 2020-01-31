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
    public class InsuranceTypeBL : IInsuranceTypeBL
    {
        private readonly IInsuranceTypeRepository _insuranceTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsuranceTypeBL(IUnitOfWork unitOfWork,
                             IMapper mapper, 
                             IConfiguration configuration,
                             IInsuranceTypeRepository insuranceTypeRepository)
        {
            _insuranceTypeRepository= insuranceTypeRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public void getAllInsuranceType()
        {
            throw new NotImplementedException();
        }
    }
}