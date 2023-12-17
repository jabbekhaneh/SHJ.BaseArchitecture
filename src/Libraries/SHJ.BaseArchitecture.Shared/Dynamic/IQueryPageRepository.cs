using SHJ.BaseArchitecture.Domain.Dynamic;

namespace SHJ.BaseArchitecture.Shared.Dynamic;

public interface IQueryPageRepository : IBaseQueryRepository<Page>, ITransientDependency
{

}
