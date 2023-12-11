using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Infrastructure;
using SHJ.BaseFramework.AspNet;
using SHJ.BaseFramework.Shared;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Application;

public static class ApplicationDependencies
{
    public static IServiceCollection BuildApplication(this IServiceCollection services,
        string databaseName)
    {
        services.BuildInfrastructure();
        services.AddSHJExceptionHandler();
        services.AddSHJBaseFrameworkAspNet(option =>
        {
            option.DatabaseName = databaseName;
            option.DatabaseType = DatabaseType.MsSql;
        });
        return services;
    }

    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        app.UseSHJBaseFrameworkAspNet();
        return app;
    }
}
