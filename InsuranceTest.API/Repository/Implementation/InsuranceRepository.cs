using InsuranceTest.API.Data;
using InsuranceTest.API.Models;
using InsuranceTest.API.Repository.Interface;

namespace InsuranceTest.API.Repository.Implementation
{
    public class InsuranceRepository: RepositoryBase<Insurance>, IInsuranceRepository
    {
        public InsuranceRepository(DataContext context) : base(context)
        {
        }

    }
}