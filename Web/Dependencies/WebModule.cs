namespace Levelnis.Learning.AutofacExamples.Web.Dependencies
{
    using System.Reflection;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using CommandQuery.Factories;
    using Infrastructure;
    using Module = Autofac.Module;

    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(WebModule).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IViewModelFactory<,>)))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().InstancePerLifetimeScope();
            builder.RegisterType<UserHandler>().As<IUserHandler>().InstancePerLifetimeScope();

            builder.RegisterFilterProvider();
            builder.RegisterType<ExtensibleActionInvoker>().As<IActionInvoker>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InjectActionInvoker();

            builder.RegisterModule<CoreModule>();
        }
    }
}