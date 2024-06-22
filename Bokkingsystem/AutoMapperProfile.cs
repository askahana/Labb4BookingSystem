using AutoMapper;
using Bokkingsystem.Data;
using Bokkingsystem.Models.DTOs;
using Bokkingsystem.Models.Entities;


namespace Bokkingsystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment >();
            CreateMap<LoginDTO, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<LoginDTO, Customer>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

            CreateMap<LoginDTO, Company>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));

           // CreateMap<Company, LoginDTO>();
            //CreateMap<Customer, LoginDTO>();
            //CreateMap<LoginDTO, AppUser>();
        }

    }
}
