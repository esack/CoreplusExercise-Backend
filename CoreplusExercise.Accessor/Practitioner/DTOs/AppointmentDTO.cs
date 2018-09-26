using System;

namespace CoreplusExercise.Accessor.Practitioner.DTOs
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Revenu { get; set; }
        public string AppointmentType { get; set; }
        public int AppointmentDuration { get; set; }
    }
}
