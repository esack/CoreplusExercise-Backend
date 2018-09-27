using AutoMapper;
using CoreplusExercise.Accessor.Practitioner.DOs;
using CoreplusExercise.Accessor.Practitioner.DTOs;
using System.Linq;

namespace CoreplusExercise.Accessor.Practitioner.TypeMappings
{
    public class PractitionerAccessorProfile : Profile
    {
        public PractitionerAccessorProfile()
        {
            CreateMap<PractitionerDO, PractitionerDTO>()
                .IncludeBase<PractitionerDO, PractitionerBaseDTO>();

            CreateMap<PractitionerDO, PractitionerDTO>()
                .ForMember(practitionerDTO => practitionerDTO.Cost, opt => opt.ResolveUsing(practitionerDO => practitionerDO.Appointments.Sum(r => r.Cost)))
                .ForMember(practitionerDTO => practitionerDTO.Revenu, opt => opt.ResolveUsing(practitionerDO => practitionerDO.Appointments.Sum(r => r.Revenu)));

            CreateMap<PractitionerDO, PractitionerBaseDTO>();

            CreateMap<AppointmentDO, AppointmentDTO>()
                .ForMember(appointmentDTO => appointmentDTO.AppointmentType, opt => opt.ResolveUsing<LookupAppointmentTypeResolver>());

            CreateMap<IGrouping<PractitionerDO, AppointmentDO>, PractitionerBaseDTO>()
                .ForMember(practitionerBaseDTO => practitionerBaseDTO.Cost, opt => opt.ResolveUsing(group => group.Sum(a => a.Cost)))
                .ForMember(practitionerBaseDTO => practitionerBaseDTO.Revenu, opt => opt.ResolveUsing(group => group.Sum(a => a.Revenu)))
                .AfterMap((src, dest, cntx) =>
                {
                    dest = cntx.Mapper.Map(src.Key, dest);
                });

            CreateMap<Mock.DTOs.AppointmentDTO, AppointmentDO>();
            CreateMap<Mock.DTOs.PractitionerDTO, PractitionerDO>();
        }
    }
}
