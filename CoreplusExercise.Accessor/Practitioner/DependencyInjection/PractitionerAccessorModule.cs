using Autofac;

namespace CoreplusExercise.Accessor.Practitioner.DependencyInjection
{
    public class PractitionerAccessorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PractitionerAccessor>().As<IPractitionerAccessor>();
            builder.RegisterType<PractitionerContext>().InstancePerRequest();
        }
    }
}
