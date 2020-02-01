using AutoMapper;
using Microsoft.Extensions.Configuration;
using InsuranceTest.API.Business.Interface;
using InsuranceTest.API.Repository.Interface;
using System.Collections.Generic;
using InsuranceTest.API.DTO.Client;
using System.Linq;
using InsuranceTest.API.Models;

namespace InsuranceTest.API.Business.Implementation
{
    public class ClientBL : IClientBL
    {
        private readonly IClientRepository _clientRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ClientBL(IUnitOfWork unitOfWork,
                             IMapper mapper, 
                             IConfiguration configuration,
                             IClientRepository clientRepository)
        {
            _clientRepository= clientRepository;
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }

        public IEnumerable<ClientDTO> getAllClients()
        {
            var Clients=  _clientRepository.GetAll();

            return _mapper.Map<IEnumerable<ClientDTO>>(Clients.AsEnumerable());

        }
    }
}