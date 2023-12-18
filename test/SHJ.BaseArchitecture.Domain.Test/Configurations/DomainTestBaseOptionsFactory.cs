using SHJ.BaseFramework.Shared;
using Microsoft.Extensions.Options;

namespace SHJ.BaseArchitecture.Domain.Test.Configurations;

public class DomainTestBaseOptionsFactory
{
    public static IOptions<BaseOptions> GetOption ()=> Options.Create(new BaseOptions
    {
        DatabaseType = DatabaseType.InMemory,
    });

    
}