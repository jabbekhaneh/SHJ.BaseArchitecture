using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.Dynamic;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseArchitecture.Domain.Test.Dynamic;

public class PageManagerTest : DomainTestBase
{
    private PageManager _Sut;
    private IBaseCommandRepository<Page> _commandRepository;
    private IBaseQueryableRepository<Page> _queryable;
    public PageManagerTest()
    {
        _commandRepository = new PageEFCommandRepository(DatabaseInMemory);
        _queryable = new PageEFQueryRepository(DatabaseInMemory);
        _Sut = new PageManager(_queryable, _commandRepository);
    }

    [Fact]
    public async Task test()
    {
        await _Sut.Insert("HASAN");
        DatabaseInMemory.SaveChanges();
        DatabaseInMemory.Pages.Any(_ => _.Title == "HASAN");
    }
}
