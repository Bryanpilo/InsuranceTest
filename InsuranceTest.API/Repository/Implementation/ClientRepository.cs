using InsuranceTest.API.Data;
using InsuranceTest.API.Models;
using InsuranceTest.API.Repository.Interface;

namespace InsuranceTest.API.Repository.Implementation
{
    public class ClientRepository: RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context)
        {
        }

    }
}