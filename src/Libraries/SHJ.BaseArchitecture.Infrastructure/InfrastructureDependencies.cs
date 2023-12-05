using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseArchitecture.Infrastructure;

public static class InfrastructureDependencies
{
    public static IServiceCollection BuildInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ISeadData, SeadData>();
        services.BuildPages();
        services.BuildEntityframework();
        return services;
    }
    private static IServiceCollection BuildPages(this IServiceCollection services)
    {
        services.AddScoped<IQueryPageRepository, DapperPageRepository>();
        services.AddScoped<ICommandPageRepository, EFPageRepository>();
        services.AddScoped<IPageRepository, PageRepository>();
        return services;
    }
    private static IServiceCollection BuildEntityframework(this IServiceCollection services)
    {
        services.AddDbContext<EfDbContext>();
        services.AddScoped<BaseCommandUnitOfWork, EFUnitOfWork>();

        return services;
    }
}
