using Autofac;
using Autofac.Builder;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Domain.Test.Configurations;
using SHJ.BaseArchitecture.Domain.Test.Configurations.Fakes;
using SHJ.BaseArchitecture.Domain.Test.Configurations.Fixtures;
using SHJ.BaseArchitecture.Infrastructure;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;
using SHJ.BaseFramework.DependencyInjection.Modules;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Domain.Test;

public abstract class DomainTestBase : BaseTestServiceProvider  
{
    protected EfDbContext DatabaseInMemory;

    public DomainTestBase()
    {
        DatabaseInMemory = GetRequiredService<EfDbContext>();
        DatabaseInMemory.Database.EnsureCreated();
    }


    public void Initialize()
    {
        using (var scope = RootServiceProvider.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetService<ISeadData>();
            dbInitializer.Initialize();
            dbInitializer.SeedData();
        }
    }

  
}
