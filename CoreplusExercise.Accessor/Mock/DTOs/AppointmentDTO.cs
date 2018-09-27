using System;

namespace CoreplusExercise.Accessor.Mock.DTOs
{
    public class AppointmentDTO
    {
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Revenu { get; set; }
        public int AppointmentType { get; set; }
        public int AppointmentDuration { get; set; }
    }
}
