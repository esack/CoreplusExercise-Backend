using System.Collections.Generic;

namespace CoreplusExercise.Accessor.Practitioner.DTOs
{
    public class PractitionerDTO : PractitionerBaseDTO
    {
        public List<AppointmentDTO> Appointments { get; set; }
    }
}
