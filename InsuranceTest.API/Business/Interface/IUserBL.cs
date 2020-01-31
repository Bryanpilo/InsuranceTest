using InsuranceTest.API.DTO.User;

namespace InsuranceTest.API.Business.Interface
{
    public interface IUserBL
    {
        bool Register(UserRegisterDTO userRegisterDTO);
        UserDTO Login(UserLoginDTO userLoginDTO);

        FullUserDTO fullUser(string username);
    
    }
}