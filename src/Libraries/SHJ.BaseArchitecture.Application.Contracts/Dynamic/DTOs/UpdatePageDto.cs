using System.ComponentModel.DataAnnotations;

namespace SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;

public class UpdatePageDto
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
}
