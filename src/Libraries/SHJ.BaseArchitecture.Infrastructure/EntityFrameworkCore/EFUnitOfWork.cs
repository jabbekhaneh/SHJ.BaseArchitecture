using SHJ.BaseFramework.Repository;

namespace SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;

public class EFUnitOfWork : BaseCommandUnitOfWork
{
    private readonly EfDbContext _dbContext;
    public EFUnitOfWork(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void BeginTransaction()
    {
        throw new NotImplementedException();
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public async Task<int> CommitAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void CommitTransaction()
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }
}
