using System.Collections.Generic;
using InsuranceTest.API.DTO.Client;
using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IClientBL
    {
        IEnumerable<ClientDTO> getAllClients();
    
    }
}