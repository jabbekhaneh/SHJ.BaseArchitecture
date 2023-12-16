using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SHJ.BaseArchitecture.Domain.Test.Configurations.Fakes;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations;

public abstract class MssqlTestInMemory
{
    protected readonly EfDbContext DatabaseInMemory;
    protected readonly BaseClaimService _baseClaimService;
    protected readonly IOptions<BaseOptions> baseOption = Options.Create<BaseOptions>(new BaseOptions
    {
        DatabaseType = DatabaseType.InMemory,
    });
    protected DbContextOptions<EfDbContext> dataBaseOption;
    public MssqlTestInMemory()
    {
        _baseClaimService = new ClaimServiceFake();
        dataBaseOption = new DbContextOptions<EfDbContext>();
        DatabaseInMemory = new EfDbContext(dataBaseOption, _baseClaimService, baseOption);
    }



}
