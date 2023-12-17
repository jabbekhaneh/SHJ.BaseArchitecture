namespace SHJ.BaseArchitecture.Shared.Dynamic;

public interface IPageRepository : ITransientDependency
{
    ICommandPageRepository Command { get; }
    IQueryPageRepository Query { get; }
    IPageDapperQueryRepository Dapper { get; }
}

