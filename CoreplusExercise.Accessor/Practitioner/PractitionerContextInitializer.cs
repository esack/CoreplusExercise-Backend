using AutoMapper;
using CoreplusExercise.Accessor.Mock;
using CoreplusExercise.Accessor.Practitioner.DOs;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;

namespace CoreplusExercise.Accessor.Practitioner
{
    public static class PractitionerContextInitializer
    {
        public static void Initialize(PractitionerContext context, IMockAccessor mockAccessor, IMapper mapper)
        {
            context.Database.EnsureCreated();

            if (context.Practitioners.Any())
            {
                return;  // DB has been seeded
            }

            var practitioners = mapper.Map<List<PractitionerDO>>(mockAccessor.GetPractitionerData(25));

            foreach (var practitioner in practitioners)
            {
                Random rnd = new Random();
                int count = rnd.Next(1, 1500);
                practitioner.Appointments = mapper.Map<List<AppointmentDO>>(mockAccessor.GetAppointmentData(count));

                context.Practitioners.Add(practitioner);
            }

            context.SaveChanges();
        }
    }
}
