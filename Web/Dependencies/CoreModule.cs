namespace Levelnis.Learning.AutofacExamples.Web.Dependencies
{
    using Autofac;
    using Core.Infrastructure;

    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NLogLogger>().As<ILogger>().InstancePerLifetimeScope();
            builder.RegisterType<MembershipProvider>().As<IMembershipProvider>().InstancePerLifetimeScope();
        }
    }
}