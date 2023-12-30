using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SHJ.BaseArchitecture.Application.Contracts.Identity;
using SHJ.BaseArchitecture.Domain.Identity;
using SHJ.BaseFramework.AspNet.Services;

namespace SHJ.BaseArchitecture.Application.Identity.v1;

[BaseControllerName("Role")]
public class RoleAppServices : BaseAppService, IRoleAppServices
{
    private readonly RoleManager<Role> _roleManager;
    public RoleAppServices(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task CreateRole(CreateRoleDto input)
    {
        var newRole = new Role { Name = input.Name};
        await _roleManager.CreateAsync(newRole);

    }
}
