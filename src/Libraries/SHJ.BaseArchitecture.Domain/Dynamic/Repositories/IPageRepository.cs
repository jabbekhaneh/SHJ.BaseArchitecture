namespace SHJ.BaseArchitecture.Domain.Dynamic.Repositories;

public interface IPageRepository
{
    ICommandPageRepository Command { get; }
    IQueryPageRepository Query { get; }
}

