using SHJ.BaseFramework.Shared;
using Microsoft.Extensions.Options;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations;

public class EntityFrameworkCoreFactory
{
    public static IOptions<BaseOptions> GetOption ()=> Options.Create(new BaseOptions
    {
        DatabaseType = DatabaseType.InMemory,
    });
    
}