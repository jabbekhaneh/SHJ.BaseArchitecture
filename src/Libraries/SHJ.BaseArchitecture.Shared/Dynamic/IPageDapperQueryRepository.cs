namespace SHJ.BaseArchitecture.Shared.Dynamic;

public interface IPageDapperQueryRepository
{
    public Task<bool> IsExistByTitleAsync(string title);
}
