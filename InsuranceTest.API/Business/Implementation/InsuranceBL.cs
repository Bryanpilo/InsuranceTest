using System;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.Repository.Interface;
using InsuranceTest.API.DTO.Client;
using System.Collections.Generic;
using InsuranceTest.API.DTO.InsuranceType;
using InsuranceTest.API.Models;
using System.Linq;

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
            _insuranceRepository = insuranceRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public bool addInsurance(InsuranceDTO insuranceDTO)
        {
            Insurance insurance = new Insurance
            {
                Name = insuranceDTO.Name,
                Description = insuranceDTO.Description,
                Coverage = insuranceDTO.Coverage,
                CoverageMonths = insuranceDTO.CoverageMonths,
                InitDate = insuranceDTO.InitDate,
                Price = insuranceDTO.Price,
                ClientId = 1,
                RiskTypeId = insuranceDTO.RiskType.Id
                // RiskType = _mapper.Map<RiskType>()
                // InsuranInsurance_InsuranceTypeceTypes = _mapper.Map<ICollection<Insurance_InsuranceType>>(insuranceDTO.InsuranceTypes.ToList())
            };

            _insuranceRepository.Add(insurance);

            _unitOfWork.Save();

            return true;
        }

        public bool deleteInsurance(int Id)
        {
            _insuranceRepository.DeleteWhere(x => x.Id == Id);

            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<InsuranceDTO> getAllInsuranceByClientID(int Id)
        {

            var Insurance = _insuranceRepository.GetAll();

            return _mapper.Map<IEnumerable<InsuranceDTO>>(Insurance.AsEnumerable());
        }

        public bool IsInsuranceHighRiskValidated(int RiskId, float Coverage)
        {
            return RiskId == 4 && Coverage > 50 ? false : true;
        }
    }
}