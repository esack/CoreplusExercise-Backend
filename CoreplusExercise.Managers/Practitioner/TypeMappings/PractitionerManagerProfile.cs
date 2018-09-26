using AutoMapper;
using CoreplusExercise.Managers.Practitioner.DTOs;
using System.Linq;

namespace CoreplusExercise.Managers.Practitioner.TypeMappings
{
    public class PractitionerManagerProfile : Profile
    {
        public PractitionerManagerProfile()
        {
            CreateMap<Accessor.Practitioner.DTOs.PractitionerBaseDTO, PractitionerBaseDTO>();

            CreateMap<Accessor.Practitioner.DTOs.PractitionerDTO, PractitionerDTO>()
                .IncludeBase<Accessor.Practitioner.DTOs.PractitionerDTO, PractitionerBaseDTO>();

            CreateMap<Accessor.Practitioner.DTOs.AppointmentDTO, AppointmentDTO>();
        }
    }
}
