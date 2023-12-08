using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseFramework.Domain;
using SHJ.BaseFramework.Shared;
using System.Reflection;

namespace SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;

public class EfDbContext : DbContext
{
    private IOptions<BaseOptions> Options;
    private BaseClaimService ClaimService;
    //public EfDbContext() { }
    
    public EfDbContext(DbContextOptions<EfDbContext> options, BaseClaimService claimService, IOptions<BaseOptions> baseOptions) : base(options)
    {
        ClaimService = claimService;
        Options = baseOptions;
    }
    public virtual DbSet<Page> Pages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Options.Value.UseInMemoryDatabase)
        {
            optionsBuilder.UseInMemoryDatabase("dbInMemory");
            optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
        else
        {
            optionsBuilder.UseSqlServer(Options.Value.ConnectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }


    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        if (ClaimService.IsAuthenticated())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateOn(ClaimService.GetUserId());
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdateOn(ClaimService.GetUserId());
                        break;
                }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
