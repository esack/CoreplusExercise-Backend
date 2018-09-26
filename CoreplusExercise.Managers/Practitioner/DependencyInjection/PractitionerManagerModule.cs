using Autofac;

namespace CoreplusExercise.Managers.Practitioner.DependencyInjection
{
    public class PractitionerManagerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PractitionerManager>().As<IPractitionerManager>();
        }
    }
}
