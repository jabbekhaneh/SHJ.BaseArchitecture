using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Domain.Test.Configurations.Fakes;
using SHJ.BaseFramework.DependencyInjection.Modules;
using SHJ.BaseFramework.Shared;
using Microsoft.AspNetCore.Http;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations;

public abstract class BaseTestServiceProvider
{
    protected IServiceProvider RootServiceProvider { get; set; } = GetServiceProvider();


   

    protected virtual T? GetService<T>()
    {
        return RootServiceProvider.GetService<T>();
    }

    protected virtual T GetRequiredService<T>() where T : notnull
    {
        return RootServiceProvider.GetRequiredService<T>();
    }


    private static IServiceProvider GetServiceProvider()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterModule<AutofacModule>();

        containerBuilder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
        containerBuilder.RegisterType<ClaimServiceFake>().As<BaseClaimService>().InstancePerDependency();

        containerBuilder.RegisterType<EfDbContext>()
       .InstancePerLifetimeScope()
       .WithParameter("options", new DbContextOptions<EfDbContext>())
       .WithParameter("baseOptions", DomainTestBaseOptionsFactory.GetOption());

        containerBuilder.RegisterType<PageManager>().As<PageManager>().InstancePerLifetimeScope();

        return new AutofacServiceProvider(containerBuilder.Build(ContainerBuildOptions.IgnoreStartableComponents));
    }

    
}
