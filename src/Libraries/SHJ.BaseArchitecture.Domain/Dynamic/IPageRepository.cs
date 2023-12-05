namespace SHJ.BaseArchitecture.Domain.Dynamic;

public interface IPageRepository
{
    ICommandPageRepository Command { get; }
    IQueryPageRepository Query { get; }
}

