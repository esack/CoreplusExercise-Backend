using System;

namespace CoreplusExercise.Accessor.Practitioner.DTOs
{
    public class PractitionerBaseDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Cost { get; set; }
        public decimal Revenu { get; set; }
    }
}
