using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore.Data;


public class SeadData : ISeadData
{
    private readonly IServiceScopeFactory _scopeFactory;
    public SeadData(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }
    public void Initialize()
    {
        using (var serviceScope = _scopeFactory.CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<EfDbContext>())
            {
                context.Database.Migrate();
            }
        }
    }

    public void SeedData()
    {
        using (var serviceScope = _scopeFactory.CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<EfDbContext>())
            {

            }
        }
    }
}

