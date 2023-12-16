using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Infrastructure;
using SHJ.BaseFramework.AspNet;
using SHJ.BaseFramework.AspNet.Mvc;
using SHJ.BaseFramework.Shared;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Application;

public static class ApplicationDependencies
{
    public static IServiceCollection BuildApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.BuildInfrastructure();
        services.AddSHJExceptionHandler(option => { });

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

        services.AddBaseMvcApplication();
        services.AddBaseCorsConfig();
        return services;
    }

    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        app.UseSHJBaseFrameworkAspNet();
        app.UseSHJExceptionHandler();
        app.UseHttpsRedirection();
        app.UseBaseCorsConfig();

        return app;
    }

    #region CorsConfig
    public static IApplicationBuilder UseBaseCorsConfig(this IApplicationBuilder app)
    {
        app.UseCors("EnableCorse");
        return app;
    }
    private static IServiceCollection AddBaseCorsConfig(this IServiceCollection services)
    {
        services.AddCors(option => option.AddPolicy("EnableCorse", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
        }));
        return services;
    }

    #endregion

    #region Private Methods

    private static IServiceCollection AddBaseMvcApplication(this IServiceCollection services)
    {        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        return services;
    }




    #endregion
}




