using CoreplusExercise.Accessor.Practitioner.DOs;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoreplusExercise.Accessor.Practitioner
{
    public class PractitionerContext : DbContext
    {
        public PractitionerContext(DbContextOptions<PractitionerContext> options) : base(options)
        {

        }

        internal DbSet<PractitionerDO> Practitioners { get; set; }
        internal DbSet<AppointmentDO> Appointments { get; set; }
    }
}
