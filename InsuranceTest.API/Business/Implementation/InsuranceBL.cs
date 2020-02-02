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
using InsuranceTest.API.Helper;

namespace InsuranceTest.API.Business.Implementation
{
    public class InsuranceBL : IInsuranceBL
    {
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IInsuranceTypeRepository _insuranceTypeRepository;
        private readonly IInsurance_InsuranceTypeRepository _insurance_InsuranceTypeRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly InsuranceValidations _insuranceValidations;

        public InsuranceBL(IUnitOfWork unitOfWork,
                             IMapper mapper,
                             IConfiguration configuration,
                             IInsuranceRepository insuranceRepository,
                             InsuranceValidations insuranceValidations,
                             IInsuranceTypeRepository insuranceTypeRepository,
                              IInsurance_InsuranceTypeRepository insurance_InsuranceTypeRepository)
        {
            _insuranceTypeRepository = insuranceTypeRepository;
            _insurance_InsuranceTypeRepository = insurance_InsuranceTypeRepository;
            _insuranceValidations= insuranceValidations;
            _insuranceRepository = insuranceRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public InsuranceBL()
        {

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
                ClientId = insuranceDTO.ClientId,
                RiskTypeId = insuranceDTO.RiskId
                };

            _insuranceRepository.Add(insurance);

            _unitOfWork.Save();

            foreach(var insuranceType in insuranceDTO.insuranceTypeDTOs)
            {
                Insurance_InsuranceType insurance_InsuranceType = new Insurance_InsuranceType
                {
                    InsuranceId = insurance.Id,
                    InsuranceTypeId = insuranceType.Id
                };

                _insurance_InsuranceTypeRepository.Add(insurance_InsuranceType);

            }

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

            var Insurance = _insuranceRepository.GetAll(x =>x.ClientId==Id);

            return _mapper.Map<IEnumerable<InsuranceDTO>>(Insurance.AsEnumerable());
        }

        public InsuranceDTO getAllInsuranceByInsuranceIdAndClientId(int Id, int clientId)
        {
            var insurance = _insuranceRepository.GetSingle(x => x.ClientId == clientId && x.Id==Id);
            var data = _mapper.Map<InsuranceDTO>(insurance);

            var insurance_insuranceType = _insurance_InsuranceTypeRepository.GetAll(x=> x.InsuranceId==Id).ToList();
            List<InsuranceTypeDTO> InsuranceTypeList = new List<InsuranceTypeDTO>();
            foreach(var insuranceType in insurance_insuranceType)
            {
                var InsuranT = _insuranceTypeRepository.GetSingle(x => x.Id == insuranceType.InsuranceTypeId);
                InsuranceTypeList.Add(_mapper.Map<InsuranceTypeDTO>(InsuranT));
            }

            data.insuranceTypeDTOs = InsuranceTypeList;

            return data;
        }
    }
}