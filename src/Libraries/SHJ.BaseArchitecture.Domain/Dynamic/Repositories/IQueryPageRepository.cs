using SHJ.BaseFramework.Repository;

namespace SHJ.BaseArchitecture.Domain.Dynamic.Repositories;

public interface IQueryPageRepository : BaseQueryRepository<Page>
{
    public Task<bool> IsExistByTitleAsync(string title);
}
