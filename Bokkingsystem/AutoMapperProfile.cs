using AutoMapper;
using BookingModels;
using BookingModels.DTOs;

namespace Bokkingsystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AppointmentDto, Appointment >();
        }

    }
}
