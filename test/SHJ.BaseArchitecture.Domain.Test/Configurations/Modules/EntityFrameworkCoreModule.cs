using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SHJ.BaseArchitecture.Domain.Test.Configurations.Fakes;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations.Modules;

public class EntityFrameworkCoreModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
        builder.RegisterType<ClaimServiceFake>().As<IBaseClaimService>().InstancePerDependency();

        builder.RegisterType<EfDbContext>()
       .InstancePerLifetimeScope()
       .WithParameter("options", new DbContextOptions<EfDbContext>())
       .WithParameter("baseOptions", EntityFrameworkCoreFactory.GetOption());
    }
}
