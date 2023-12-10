using SHJ.BaseFramework.Domain;

namespace SHJ.BaseArchitecture.Domain.Dynamic;

public class Page : BaseEntity
{
    public string Title { get; private set; } = string.Empty;
    public Page(string title)
    {
        this.Title = title.Trim().ToLower();
    }

}
