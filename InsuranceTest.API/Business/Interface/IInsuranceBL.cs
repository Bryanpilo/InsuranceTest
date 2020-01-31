using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IInsuranceBL
    {
        bool Register(UserRegisterDTO userRegisterDTO);
        UserDTO Login(UserLoginDTO userLoginDTO);

        FullUserDTO fullUser(string username);
    
    }
}