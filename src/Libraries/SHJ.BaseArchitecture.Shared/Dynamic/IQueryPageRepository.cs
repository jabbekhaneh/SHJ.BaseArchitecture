using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseArchitecture.Shared.Dynamic;

public interface IQueryPageRepository : BaseQueryRepository<Page>
{
    public Task<bool> IsExistByTitleAsync(string title);
}
