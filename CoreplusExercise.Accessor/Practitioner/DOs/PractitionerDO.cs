using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreplusExercise.Accessor.Practitioner.DOs
{
    [Table("Practitioners")]
    internal class PractitionerDO
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<AppointmentDO> Appointments { get; set; }
    }
}
