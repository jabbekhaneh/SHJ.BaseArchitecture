using SHJ.BaseArchitecture.Domain.Dynamic;


namespace SHJ.BaseArchitecture.Shared.Dynamic;


public interface ICommandPageRepository : IBaseCommandRepository<Page>, ITransientDependency
{

}
