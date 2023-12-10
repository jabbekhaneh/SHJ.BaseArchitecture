namespace SHJ.BaseArchitecture.Shared.Dynamic;

public interface IPageRepository
{
    ICommandPageRepository Command { get; }
    IQueryPageRepository Query { get; }
}

