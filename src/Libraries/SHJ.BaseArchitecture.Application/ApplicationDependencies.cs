using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Infrastructure;
using SHJ.BaseFramework.AspNet;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Application;

public static class ApplicationDependencies
{
    public static IServiceCollection BuildApplication(this IServiceCollection services)
    {
        services.BuildInfrastructure();
        services.AddSHJExceptionHandler();
        services.AddSHJBaseFrameworkAspNet();
        return services;
    }

    public static void UseApplication(this IApplicationBuilder app)
    {
        app.UseSHJExceptionHandler();
    }
}
