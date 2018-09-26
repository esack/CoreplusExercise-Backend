using System.Collections.Generic;

namespace CoreplusExercise.Api.DTOs
{
    public class PractitionerDTO : PractitionerBaseDTO
    {
        public List<AppointmentDTO> Appointments { get; set; }
    }
}
