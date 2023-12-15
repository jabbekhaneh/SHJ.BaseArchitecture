global using SHJ.BaseArchitecture.Web.API;
using SHJ.BaseArchitecture.Application;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;

namespace SHJ.BaseArchitecture.Web.API;

public static class HostExtentions
{
    //##################  Application Services  ####################
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.BuildApplication(builder.Configuration);
        builder.Services.AddSwaggerGen();
        return builder.Build();
    }
    //##################  Application Builder  ####################
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseApplication();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

        using (var scope = scopeFactory.CreateScope())
        {
            var dbInitializer = scope.ServiceProvider.GetService<ISeadData>();
            dbInitializer.Initialize();
            dbInitializer.SeedData();
        }
        app.MapControllers();
        return app;
    } 
}
