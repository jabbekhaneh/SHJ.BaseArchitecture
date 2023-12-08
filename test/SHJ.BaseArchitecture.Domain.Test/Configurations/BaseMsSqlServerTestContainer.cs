using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseFramework.Shared;
using Testcontainers.MsSql;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations;

public abstract class BaseMsSqlServerTestContainer : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer
       = new MsSqlBuilder().Build();
    private DbContextOptions<EfDbContext> DbContextOptions;
    private string _connectionString = string.Empty;
    protected readonly EfDbContext DatabaseContext;
    protected readonly BaseClaimService BaseClaimService;
    protected readonly IOptions<BaseOptions> BaseOption;
    public BaseMsSqlServerTestContainer()
    {
        _connectionString = _msSqlContainer.GetConnectionString();
        BaseOption = Options.Create<BaseOptions>(new BaseOptions
        {
            ConnectionStringTestContainer = _connectionString,
        });
        BaseClaimService = new BaseClaimServiceFake();
        DbContextOptions = new DbContextOptions<EfDbContext>();
        DatabaseContext = new EfDbContext(DbContextOptions, BaseClaimService, BaseOption);
    }

    public async Task InitializeAsync()
    => await _msSqlContainer.StartAsync();

    public async Task DisposeAsync()
         => await _msSqlContainer.DisposeAsync().AsTask();
}
