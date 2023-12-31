﻿global using SHJ.BaseArchitecture.Web.API;
global using Serilog;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using SHJ.BaseArchitecture.Application;
using SHJ.BaseFramework.DependencyInjection.Modules;
using SHJ.BaseSwagger;
using Serilog.Events;
using SHJ.BaseArchitecture.Infrastructure;

namespace SHJ.BaseArchitecture.Web.API;

public static class HostExtentions
{
    //##################  Application Services  ####################
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.BuildApplication(builder.Configuration);
        builder.Services.RegisterSwagger(options =>
        {
            options.ProjectName = "*** BaseArchitecture API ***";
        });

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                   .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));
        
        return builder;
    }
    //##################  Application Builder  ####################
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseApplication();

        if (app.Environment.IsDevelopment())
        {
            app.RegisterUseSwaggerAndUI(app.Services);
        }

        app.Services.InitializeDatabase();

        app.MapControllers();
        return app;
    }

    //##################  Host  Logger  ####################
    public static WebApplicationBuilder ConfigureHostLogger(this WebApplicationBuilder builder)
    {
        
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.File("Logs/logs.txt")
        .WriteTo.Console()
        .CreateLogger();
        Log.Information("Starting SHJ.BaseArchitecture.Web.API");
        builder.Host.UseSerilog();
        return builder;
    }

   

}
