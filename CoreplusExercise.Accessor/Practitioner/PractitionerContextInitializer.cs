using CoreplusExercise.Accessor.Practitioner.DOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace CoreplusExercise.Accessor.Practitioner
{
    public static class PractitionerContextInitializer
    {
        public static void Initialize(PractitionerContext context)
        {
            context.Database.EnsureCreated();

            if (context.Practitioners.Any())
            {
                return;  // DB has been seeded
            }

            var practitioner = new PractitionerDO
        }
    }
}
