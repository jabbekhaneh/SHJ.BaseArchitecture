using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Domain.Test.Dynamic;

public class PageManagerTest : DomainTestBase
{
    private PageManager _Sut;

    public PageManagerTest()
    {
        _Sut = GetRequiredService<PageManager>();
    }

    //------------------------------------------------
    [Fact]
    public async Task InsertPage_WhenExecutePageManager_ShouldReturnTheExpecedPage()
    {
        //arrange
        string title = "Dummy-Title-One".ToLower();

        //act
        await _Sut.Insert(title);
        DatabaseInMemory.SaveChanges();

        //assert
        var query = DatabaseInMemory.Pages.ToList();
        DatabaseInMemory.Pages.Any(_ => _.Title == title).Should().BeTrue();
    }
    //------------------------------------------------
    [Fact]
    public async Task InsertPage_WhenExecutePageManager_ShouldExceptionDublicateTitle()
    {
        //arrange
        string title = "Dummy-Title".ToLower();
        var page = new Page(title);
        DatabaseInMemory.Pages.Add(page);
        DatabaseInMemory.SaveChanges();

        //act
        Func<Task> expected = () => _Sut.Insert(title);


        //assert
        await expected.Should().ThrowAsync<BaseBusinessException>();
        var exception = await Assert.ThrowsAsync<BaseBusinessException>(expected);
        exception.Code.Should().Be(DomainGlobalErrorCodes.DublicatePageTitle);
    }
    //------------------------------------------------
    [Fact]
    public void UpdatePageById_WhenExecutePageManager_ShouldReturnTheExpecedPage()
    {
        //arrange
        string title = "Dummy-Title-two";
        var page = new Page(title);
        DatabaseInMemory.Pages.Add(page);
        DatabaseInMemory.SaveChanges();
        string updateTitle = "HomePage";

        //act
        _Sut.Update(page.Id, updateTitle);
        DatabaseInMemory.SaveChanges();

        //assert
        DatabaseInMemory.Pages.Single(_ => _.Id == page.Id).Title.Should().Be(updateTitle);
    }
    //------------------------------------------------
    [Fact]
    public void UpdatePageById_WhenExecutePageManager_ShouldExceptionNotFoundPage()
    {
        //arrange
        Guid id = Guid.NewGuid();

        //act
        var actual = Assert.Throws<BaseBusinessException>(() => _Sut.Update(id, "FakeId"));


        //assert

        actual.Code.Should().Be(DomainGlobalErrorCodes.NotFoundPage);
    }
    //------------------------------------------------
    [Fact]
    public void UpdatePageById_WhenExecutePageManager_ShouldExceptionDublicateTitle()
    {
        //arrange
        var pageOne = new Page("title-on");
        var pageTwo = new Page("title-two");
        DatabaseInMemory.Pages.Add(pageOne);
        DatabaseInMemory.Pages.Add(pageTwo);
        DatabaseInMemory.SaveChanges();

        //act
        var actual = Assert.Throws<BaseBusinessException>(() => _Sut.Update(pageOne.Id, pageTwo.Title));

        //assert

        actual.Code.Should().Be(DomainGlobalErrorCodes.DublicatePageTitle);
    }
}
