using SHJ.BaseFramework.DependencyInjection.Contracts;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Domain.Dynamic;

public class PageManager : BaseDomainService<Page>
{
    public PageManager(IBaseCommandRepository<Page> commandRepository, IBaseQueryableRepository<Page> queryableRepository) : base(commandRepository, queryableRepository)
    {
    }

    public async Task<Page> Insert(string title)
    {

        if (Query.Any(_ => _.Title == title))
            throw new BaseBusinessException(DomainGlobalErrorCodes.DublicatePageTitle);

        var newPage = new Page(title);
        await CommandRepository.InsertAsync(newPage);

        return newPage;
    }

    public void Update(Guid id, string title)
    {
        var page = Query.SingleOrDefault(_ => _.Id == id);
        if (page is null)
            throw new BaseBusinessException(DomainGlobalErrorCodes.NotFoundPage);

        if (Query.Any(_ => _.Title == title && page.Title != _.Title))
            throw new BaseBusinessException(DomainGlobalErrorCodes.DublicatePageTitle);

        page.Title = title;
    }
}
