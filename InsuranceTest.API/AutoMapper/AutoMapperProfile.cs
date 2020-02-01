using AutoMapper;
using InsuranceTest.API.DTO.Client;
using InsuranceTest.API.DTO.InsuranceType;
using InsuranceTest.API.DTO.InsuranInsurance_InsuranceTypes;
using InsuranceTest.API.DTO.RiskType;
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

            CreateMap<Client, ClientDTO>()
            .ForMember(m => m.Id,
                        vm => vm.MapFrom(
                            v => v.Id))
            .ForMember(m => m.FullName,
                        vm => vm.MapFrom(
                            v => v.FullName))
            .ForMember(m => m.InitDate,
                        vm => vm.MapFrom(
                            v => v.InitDate))
            .ForMember(m => m.Salary,
                        vm => vm.MapFrom(
                            v => v.Salary))
            .ForMember(m => m.Charge,
                        vm => vm.MapFrom(
                            v => v.Charge))
            .ReverseMap();

            CreateMap<RiskType, RiskTypeDTO>()
            .ForMember(m => m.Id,
                        vm => vm.MapFrom(
                            v => v.Id))
            .ForMember(m => m.Risk,
                        vm => vm.MapFrom(
                            v => v.Risk))
            .ReverseMap();

            CreateMap<InsuranceType, InsuranceTypeDTO>()
            .ForMember(m => m.Id,
                        vm => vm.MapFrom(
                            v => v.Id))
            .ForMember(m => m.Name,
                        vm => vm.MapFrom(
                            v => v.Name))
            .ReverseMap();

            CreateMap<Insurance_InsuranceType, Insurance_InsuranceTypeDTO>()
            .ForMember(m => m.InsuranceId, opt => opt.Ignore())
            .ForMember(m => m.InsuranceTypeId,
                        vm => vm.MapFrom(
                            v => v.Id))
            .ReverseMap();

            CreateMap<Insurance, InsuranceDTO>()
            .ForMember(m => m.Id,
                        vm => vm.MapFrom(
                            v => v.Id))
            .ForMember(m => m.Name,
                        vm => vm.MapFrom(
                            v => v.Name))
            .ForMember(m => m.Description,
                        vm => vm.MapFrom(
                            v => v.Description))
            .ForMember(m => m.Coverage,
                        vm => vm.MapFrom(
                            v => v.Coverage))
            .ForMember(m => m.CoverageMonths,
                        vm => vm.MapFrom(
                            v => v.CoverageMonths))
            .ForMember(m => m.InitDate,
                        vm => vm.MapFrom(
                            v => v.InitDate))
            .ForMember(m => m.Price,
                        vm => vm.MapFrom(
                            v => v.Price))
            .ForMember(m => m.RiskName,
                        vm => vm.MapFrom(
                            v => v.RiskType.Risk))
            .ReverseMap();

        }
    }
}