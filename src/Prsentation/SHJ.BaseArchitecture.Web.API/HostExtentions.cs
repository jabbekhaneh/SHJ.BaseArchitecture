using SHJ.BaseArchitecture.Application;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;
using SHJ.BaseFramework.AspNet;

namespace SHJ.BaseArchitecture.Web.API;

public static class HostExtentions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        //var options = builder.Configuration.GetValueBaseOptions();
        //var databaseName = Environment.GetEnvironmentVariable("");

        builder.Services.BuildApplication();
        var connection = "Data Source=dbPortal; Initial Catalog=db_Portal; User ID=sa; Password=Aa@123456";
        builder.Services.AddSHJBaseFrameworkAspNet(option =>
        {
            option.DatabaseType = BaseFramework.Shared.DatabaseType.DbTest;
            option.DefualtConnectionString = connection;

        });

        builder.Services.AddCors(option => option.AddPolicy("EnableCorse", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
        }));
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseApplication();
        app.UseSHJBaseFrameworkAspNet();
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

        app.UseHttpsRedirection();

        app.UseCors("EnableCorse");



        app.MapControllers();

        return app;
    }
}
