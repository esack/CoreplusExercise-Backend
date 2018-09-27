using System;

namespace CoreplusExercise.Accessor.Mock.DOs
{
    internal class AppointmentDO
    {
        public DateTime date { get; set; }
        public decimal cost { get; set; }
        public decimal revenu { get; set; }
        public int appointment_duration { get; set; }
        public int appointment_type { get; set; }
    }
}
