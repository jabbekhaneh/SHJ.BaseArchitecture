using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Domain.Test.Configurations;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;

namespace SHJ.BaseArchitecture.Domain.Test;

public abstract class DomainTestBase : ConfigurationsServiceProvider   
{
    

    


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
