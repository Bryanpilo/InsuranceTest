using InsuranceTest.API.Data;
using InsuranceTest.API.Models;
using InsuranceTest.API.Repository.Interface;

namespace InsuranceTest.API.Repository.Implementation
{
    public class InsuranceTypeRepository: RepositoryBase<InsuranceType>, IInsuranceTypeRepository
    {
        public InsuranceTypeRepository(DataContext context) : base(context)
        {
        }

    }
}