using System.ComponentModel.DataAnnotations;

namespace SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;

public class CreatePageDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
}
