using System.Collections.Generic;

namespace CoreplusExercise.Managers.Practitioner.DTOs
{
    public class PractitionerDTO : PractitionerBaseDTO
    {
        public List<AppointmentDTO> Appointments { get; set; }
    }
}
