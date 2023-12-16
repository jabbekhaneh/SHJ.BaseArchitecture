using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Domain.Dynamic;

public class PageManager : BaseDomainService<Page>
{

    private IBaseCommandRepository<Page> CommandRepository;
    private IBaseQueryableRepository<Page> Queryable;
    public PageManager(IBaseQueryableRepository<Page> queryable, IBaseCommandRepository<Page> commandRepository)
    {
        Queryable = queryable;
        CommandRepository = commandRepository;
    }

    public async Task<Page> Insert(string title)
    {
        var pages = Queryable.GetQueryable();
        if (pages.Any(_ => _.Title == title))
            throw new BaseBusinessException(DomainGlobalErrorCodes.DublicatePageTitle);

        var newPage = new Page(title);
        await CommandRepository.InsertAsync(newPage);

        return newPage;
    }

    public async Task Update(Guid id, string title)
    {
        var pages = Queryable.GetQueryable();
        var page = pages.SingleOrDefault(_ => _.Id == id);
        if (page is null)
            throw new BaseBusinessException(DomainGlobalErrorCodes.NotFoundPage);

        if (pages.Any(_ => _.Title == title && page.Title != _.Title))
            throw new BaseBusinessException(DomainGlobalErrorCodes.DublicatePageTitle);

        page.Title = title;
    }
}
