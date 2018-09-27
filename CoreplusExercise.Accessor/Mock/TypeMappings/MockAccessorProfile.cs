using AutoMapper;
using CoreplusExercise.Accessor.Mock.DOs;
using CoreplusExercise.Accessor.Mock.DTOs;
using System.Linq;

namespace CoreplusExercise.Accessor.Mock.TypeMappings
{
    public class MockAccessorProfile : Profile
    {
        public MockAccessorProfile()
        {
            CreateMap<AppointmentDO, AppointmentDTO>()
                .ForMember(appointmentDTO => appointmentDTO.AppointmentDuration, opt => opt.MapFrom(appointmentDO => appointmentDO.appointment_duration))
                .ForMember(appointmentDTO => appointmentDTO.AppointmentType, opt => opt.MapFrom(appointmentDO => appointmentDO.appointment_type))
                .ForMember(appointmentDTO => appointmentDTO.Cost, opt => opt.MapFrom(appointmentDO => appointmentDO.cost))
                .ForMember(appointmentDTO => appointmentDTO.Date, opt => opt.MapFrom(appointmentDO => appointmentDO.date))
                .ForMember(appointmentDTO => appointmentDTO.Revenu, opt => opt.MapFrom(appointmentDO => appointmentDO.revenu));

            CreateMap<PractitionerDO, PractitionerDTO>()
                .ForMember(practitionerDTO => practitionerDTO.FirstName, opt => opt.MapFrom(practitionerDO => practitionerDO.first_name))
                .ForMember(practitionerDTO => practitionerDTO.LastName, opt => opt.MapFrom(practitionerDO => practitionerDO.last_name));

        }
    }
}
