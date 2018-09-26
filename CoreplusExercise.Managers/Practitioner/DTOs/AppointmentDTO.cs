using System;

namespace CoreplusExercise.Managers.Practitioner.DTOs
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Revenu { get; set; }
        public string AppointmentType { get; set; }
        public int AppointmentDuration { get; set; }
    }
}
