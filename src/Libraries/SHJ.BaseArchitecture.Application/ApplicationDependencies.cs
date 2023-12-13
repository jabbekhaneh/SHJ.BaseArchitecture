using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Infrastructure;
using SHJ.BaseFramework.AspNet;
using SHJ.BaseFramework.AspNet.Mvc;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Application;

public static class ApplicationDependencies
{
    public static IServiceCollection BuildApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.BuildInfrastructure();

        var sqlOption = configuration.GetValueBaseSqlOptions();

        services.AddSHJBaseFrameworkAspNet(option =>
        {
            option.DatabaseType = DatabaseType.MsSql;
            option.Environment = ASPNET_EnvironmentType.Development;
            option.SqlOptions = new BaseSqlServerOptions
            {
                ConnectToServer = DatabaseConnectType.SqlServerAuthentication,
                DatabaseName = sqlOption.DatabaseName,
                DataSource = sqlOption.DataSource,
                UserID = sqlOption.UserID,
                Password = sqlOption.Password,
            };
        });

        return services;
    }

    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        app.UseSHJBaseFrameworkAspNet();
        return app;
    }
}
