using Microsoft.AspNetCore.Identity;

namespace SHJ.BaseArchitecture.Domain.Identity;

public class User : IdentityUser<Guid>
{
    public string? Firstname { get; set; } = string.Empty;
    public string? Lastname { get; set; } = string.Empty;
    public string? Mobile { get; set; } = string.Empty;
}
