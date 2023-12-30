namespace SHJ.BaseArchitecture.Application.Contracts.Identity;

public interface IRoleAppServices
{
    Task CreateRole(CreateRoleDto input);
}
