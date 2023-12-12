using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using SHJ.BaseFramework.AspNet;
using SHJ.ExceptionHandler;
using Testcontainers.MsSql;

namespace SHJ.BaseArchitecture.Application.Test.Configurations;

public class DockerWebApplicationFactoryFixture : WebApplicationFactory<Program>, IAsyncLifetime
{
    private MsSqlContainer _dbContainer;
    public DockerWebApplicationFactoryFixture()
    {
        _dbContainer = new MsSqlBuilder().Build();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var connectionString = _dbContainer.GetConnectionString();
        base.ConfigureWebHost(builder);
        builder.ConfigureAppConfiguration(app =>
        {


        });

        builder.ConfigureTestServices(services =>
        {
            services.AddSHJBaseFrameworkAspNet(option =>
            {
                option.DefualtConnectionString = connectionString;
                option.DatabaseType = BaseFramework.Shared.DatabaseType.DbTest;
            });

        });
       
    }


    public async Task InitializeAsync()
      => await _dbContainer.StartAsync();

    public async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
    }
}


