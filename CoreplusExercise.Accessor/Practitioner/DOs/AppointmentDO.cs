using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreplusExercise.Accessor.Practitioner.DOs
{
    [Table("Appointments")]
    public class AppointmentDO
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Practitioner")]
        public Guid PractitionerId { get; set; }
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Revenu { get; set; }
        public int AppointmentType { get; set; }
        public int AppointmentDuration { get; set; }
        public PractitionerDO Practitioner { get; set; }
    }
}
