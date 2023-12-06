using SHJ.BaseArchitecture.Domain.Dynamic.Repositories;
using SHJ.BaseFramework.Domain;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Domain.Dynamic;

public class PageManager : BaseDomainService<Page>
{
    private readonly IPageRepository _repository;

    public PageManager(IPageRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Create(string title)
    {
        if (title == null)
            throw new BaseException((int)DomainErrorCodes.NotBeEmptyPageTitle);

        if (await _repository.Query.IsExistByTitleAsync(title))
            throw new BaseException((int)DomainErrorCodes.DublicatePageTitle);

         await _repository.Command.InsertAsync(new Page(title));
    }
}
