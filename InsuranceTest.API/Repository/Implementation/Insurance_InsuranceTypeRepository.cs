

using InsuranceTest.API.Data;
using InsuranceTest.API.Models;
using InsuranceTest.API.Repository.Interface;

namespace InsuranceTest.API.Repository.Implementation
{
    public class Insurance_InsuranceTypeRepository: RepositoryBase<Insurance_InsuranceType>, IInsurance_InsuranceTypeRepository
    {
        public Insurance_InsuranceTypeRepository(DataContext context) : base(context)
        {
        }

    }
}