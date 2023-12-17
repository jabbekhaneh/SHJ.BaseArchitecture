namespace SHJ.BaseArchitecture.Shared.Dynamic;

public interface IPageDapperQueryRepository : ITransientDependency
{
    public Task<bool> IsExistByTitleAsync(string title);
}
