using System;

namespace InsuranceTest.API.Repository.Interface
{
    public interface IUnitOfWork: IDisposable
    {

        void Save();
        // IUserRepository userRepository {get;}
    }
}