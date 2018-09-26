using System;

namespace CoreplusExercise.Api.DTOs
{
    public class PractitionerBaseDTO
    {
        public Guid Id { get; set; }
        public string Practitioner { get; set; }
        public decimal Cost { get; set; }
        public decimal Revenu { get; set; }

    }
}
