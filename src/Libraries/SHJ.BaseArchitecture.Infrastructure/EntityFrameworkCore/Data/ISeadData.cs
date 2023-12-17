using SHJ.BaseFramework.DependencyInjection.Contracts;

namespace SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;

public interface ISeadData : IScopedDependency
{
    void Initialize();
    void SeedData();
}
