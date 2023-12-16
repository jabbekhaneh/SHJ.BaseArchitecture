using SHJ.BaseFramework.Domain;

namespace SHJ.BaseArchitecture.Domain.Dynamic;

public class Page : BaseEntity
{
    public string Title { get; internal set; } = string.Empty;
    public Page(string title)
    {
        this.Title = title.ToLower();
    }

}
