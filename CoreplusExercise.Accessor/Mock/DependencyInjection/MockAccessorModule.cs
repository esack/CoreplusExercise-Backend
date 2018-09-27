using Autofac;

namespace CoreplusExercise.Accessor.Mock.DependencyInjection
{
    public class MockAccessorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MockAccessor>().As<IMockAccessor>();
        }
    }
}
