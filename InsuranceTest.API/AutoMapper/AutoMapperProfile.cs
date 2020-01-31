using AutoMapper;
using InsuranceTest.API.DTO.User;
using InsuranceTest.API.Models;

namespace InsuranceTest.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
            .ForMember(m => m.UserName,
                        vm => vm.MapFrom(
                            v => v.Username))
            .ForMember(m => m.Token, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<User, FullUserDTO>()
            .ForMember(m => m.Username,
                        vm => vm.MapFrom(
                            v => v.Username))
            .ReverseMap();

        }
    }
}