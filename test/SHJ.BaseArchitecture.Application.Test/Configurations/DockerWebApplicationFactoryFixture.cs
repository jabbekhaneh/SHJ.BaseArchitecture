using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseFramework.AspNet;
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
            //services.RemoveAll(typeof(DbContextOptions<EfDbContext>));
            services.AddSHJBaseFrameworkAspNet(option =>
            {
                option.ConnectionStringTestContainer = connectionString;
                option.DatabaseType = BaseFramework.Shared.DatabaseType.TestContainer;
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
