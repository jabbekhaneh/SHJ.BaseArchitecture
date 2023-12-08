using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Domain.Dynamic.Repositories;
using SHJ.BaseArchitecture.Infrastructure.Dynamic;

namespace SHJ.BaseArchitecture.Domain.Test.Dynamic;

public class PageManagerTest : BaseMsSqlServerTestContainer
{
    private PageManager _sut;
    private IPageRepository _repository;
    private ICommandPageRepository _commandPageRepository;
    private IQueryPageRepository _queryPageRepository;
    public PageManagerTest()
    {
        _commandPageRepository = new EFPageRepository(DatabaseContext);
        _queryPageRepository = new DapperPageRepository(BaseOption);
        _repository = new PageRepository(_commandPageRepository, _queryPageRepository);
        _sut = new PageManager(_repository);
    }

    [Fact]
    public async Task Create()
    {

    }
}
