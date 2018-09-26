using Newtonsoft.Json;
using System;

namespace CoreplusExercise.Api.DTOs
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public decimal Cost { get; set; }
        public decimal Revenu { get; set; }
        [JsonProperty(PropertyName = "appointment_type")]
        public string AppointmentType { get; set; }
        [JsonProperty(PropertyName = "appointment_duration")]
        public int AppointmentDuration { get; set; }
    }
}
