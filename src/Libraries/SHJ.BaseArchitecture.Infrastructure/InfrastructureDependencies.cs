using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;
using SHJ.BaseFramework.EntityFrameworkCore;
using SHJ.BaseFramework.Repository;


namespace SHJ.BaseArchitecture.Infrastructure;

public static class InfrastructureDependencies
{
    public static IServiceCollection BuildInfrastructure(this IServiceCollection services)
    {
        services.BuildPages();
        services.BuildEntityframework();
        return services;
    }
    public static IServiceProvider InitializeDatabase(this IServiceProvider serviceProvider)
    {
        var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

        using (var scope = scopeFactory.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetService<ISeadData>();
            dbInitializer.Initialize();
            dbInitializer.SeedData();
        }
        return serviceProvider;
    }




    private static IServiceCollection BuildEntityframework(this IServiceCollection services)
    {
        services.AddDbContext<EfDbContext>();
        services.AddTransient<IBaseCommandUnitOfWork, BaseEFUnitOfWork<EfDbContext>>();
        services.AddScoped<ISeadData, SeadData>();
        return services;
    }

    private static IServiceCollection BuildPages(this IServiceCollection services)
    {
        services.AddScoped<PageManager, PageManager>(); 
        return services;
    }


    
}
