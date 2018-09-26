using AutoMapper;
using CoreplusExercise.Api.DTOs;

namespace CoreplusExercise.Api.TypeMappings
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Managers.Practitioner.DTOs.PractitionerBaseDTO, PractitionerBaseDTO>();

            CreateMap<Managers.Practitioner.DTOs.PractitionerDTO, PractitionerDTO>()
                .IncludeBase<Managers.Practitioner.DTOs.PractitionerDTO, PractitionerBaseDTO>();

            CreateMap<Managers.Practitioner.DTOs.AppointmentDTO, AppointmentDTO>();
        }
    }
}
