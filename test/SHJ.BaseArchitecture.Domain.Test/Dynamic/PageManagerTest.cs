using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.Dynamic;
using SHJ.BaseFramework.Repository;
using SHJ.ExceptionHandler;

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
    public async Task InsertPage_WhenExecutePageManager_ShouldReturnTheExpecedPage()
    {
        //arrange
        string title = "Dummy-Title-One".ToLower();

        //act
        await _Sut.Insert(title);
        DatabaseInMemory.SaveChanges();

        //assert
        DatabaseInMemory.Pages.Any(_ => _.Title == title).Should().BeTrue();
    }

    [Fact]
    public async Task InsertPage_WhenExecutePageManager_ShouldExceptionDublicateTitle()
    {
        //arrange
        string title = "Dummy-Title".ToLower();
        var page = new Page(title);
        _commandRepository.Insert(page);
        DatabaseInMemory.SaveChanges();

        //act
        Func<Task> expected = () => _Sut.Insert(title);


        //assert
        await expected.Should().ThrowAsync<BaseBusinessException>();
        var exception = await Assert.ThrowsAsync<BaseBusinessException>(expected);
        exception.Code.Should().Be(DomainGlobalErrorCodes.DublicatePageTitle);
    }

    [Fact]
    public async Task UpdatePageById_WhenExecutePageManager_ShouldReturnTheExpecedPage()
    {
        //arrange
        string title = "Dummy-Title-two";
        var page = new Page(title);
        _commandRepository.Insert(page);
        DatabaseInMemory.SaveChanges();
        string updateTitle = "HomePage";

        //act
        await _Sut.Update(page.Id, updateTitle);
        DatabaseInMemory.SaveChanges();

        //assert
        DatabaseInMemory.Pages.Single(_ => _.Id == page.Id).Title.Should().Be(updateTitle);
    }

    [Fact]
    public async Task UpdatePageById_WhenExecutePageManager_ShouldExceptionNotFoundPage()
    {
        //arrange
        Guid id = Guid.NewGuid();

        //act
        Func<Task> expected = () => _Sut.Update(id, "FakeId");

        //assert

        await expected.Should().ThrowAsync<BaseBusinessException>();
        var exception = await Assert.ThrowsAsync<BaseBusinessException>(expected);
        exception.Code.Should().Be(DomainGlobalErrorCodes.NotFoundPage);
    }


    [Fact]
    public async Task UpdatePageById_WhenExecutePageManager_ShouldExceptionDublicateTitle()
    {
        //arrange
        var pageOne = new Page("title-on");
        var pageTwo = new Page("title-two");
        _commandRepository.Insert(pageOne);
        _commandRepository.Insert(pageTwo);
        DatabaseInMemory.SaveChanges();

        //act
        Func<Task> expected = () => _Sut.Update(pageOne.Id, pageTwo.Title);

        //assert

        await expected.Should().ThrowAsync<BaseBusinessException>();
        var exception = await Assert.ThrowsAsync<BaseBusinessException>(expected);
        exception.Code.Should().Be(DomainGlobalErrorCodes.DublicatePageTitle);
    }
}
