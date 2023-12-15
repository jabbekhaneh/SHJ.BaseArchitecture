using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseFramework.AspNet;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Application.Test.Fixtures;

public class IntegrationContainersAppFactory : WebApplicationFactory<Program> , IAsyncLifetime
{
    private MssqlContainerFixture SqlContainerFixture { get; }
  
    public IntegrationContainersAppFactory()
    {
        SqlContainerFixture = new MssqlContainerFixture();
        
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureAppConfiguration(app =>
        {

        });

        builder.ConfigureTestServices(services =>
        {
            var serviceProvider = services.BuildServiceProvider();
            services.AddSHJBaseFrameworkAspNet(option =>
            {
                option.DatabaseType = DatabaseType.Manual;
                option.Environment = ASPNET_EnvironmentType.Development;
                option.ManualConnectionString = SqlContainerFixture.GetConnectionString();
                
            });

        });
    }

    public async Task InitializeAsync()
    {
        await SqlContainerFixture.Container.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await SqlContainerFixture.Container.StopAsync();
    }



}