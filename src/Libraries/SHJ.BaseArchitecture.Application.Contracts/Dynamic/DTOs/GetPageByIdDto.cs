namespace SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;

public class GetPageByIdDto 
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
