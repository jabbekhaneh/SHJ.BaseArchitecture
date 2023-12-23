using Autofac;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Domain.Test.Configurations.Modules;
using SHJ.BaseFramework.DependencyInjection.Modules;

namespace SHJ.BaseArchitecture.Domain.Test;

public class DomainTestConfigureModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterModule<AutofacModule>();
        builder.RegisterModule<EntityFrameworkCoreModule>();

        builder.RegisterType<PageManager>().As<PageManager>().InstancePerLifetimeScope();

    }
}
