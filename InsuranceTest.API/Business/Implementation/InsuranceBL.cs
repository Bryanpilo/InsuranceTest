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
using InsuranceTest.API.DTO.Client;
using System.Collections.Generic;

namespace InsuranceTest.API.Business.Implementation
{
    public class InsuranceBL : IInsuranceBL
    {
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsuranceBL(IUnitOfWork unitOfWork,
                             IMapper mapper, 
                             IConfiguration configuration,
                             IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository= insuranceRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public bool addInsurance(InsuranceDTO insuranceDTO)
        {
            throw new NotImplementedException();
        }

        public bool deleteInsurance(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InsuranceDTO> getAllInsuranceByClientID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}