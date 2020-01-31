using InsuranceTest.API.Data;
using InsuranceTest.API.Models;
using InsuranceTest.API.Repository.Interface;

namespace InsuranceTest.API.Repository.Implementation
{
    public class RiskTypeRepository: RepositoryBase<RiskType>, IRiskTypeRepository
    {
        public RiskTypeRepository(DataContext context) : base(context)
        {
        }

    }
}