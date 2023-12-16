using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Repository;

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
      
        var newPage = new Page(title);
        await CommandRepository.InsertAsync(newPage);
        return newPage;
    }

    
}
