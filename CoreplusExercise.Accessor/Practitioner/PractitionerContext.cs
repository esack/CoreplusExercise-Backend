using CoreplusExercise.Accessor.Practitioner.DOs;
using Microsoft.EntityFrameworkCore;
using System;

namespace CoreplusExercise.Accessor.Practitioner
{
    public class PractitionerContext : DbContext
    {
        public DbSet<PractitionerDO> Practitioners { get; set; }
        public DbSet<AppointmentDO> Appointments { get; set; }

        //public PractitionerContext(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //}
    }
}
