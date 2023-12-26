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
    private IBaseClaimService ClaimService;
    public EfDbContext() { }
    public EfDbContext(DbContextOptions<EfDbContext> options, IBaseClaimService claimService, IOptions<BaseOptions> baseOptions) : base(options)
    {
        Options = baseOptions;
        ClaimService = claimService;
    }
    public virtual DbSet<Page> Pages { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Options.Value.DatabaseType == DatabaseType.InMemory)
        {
            optionsBuilder.UseInMemoryDatabase("App.Db");
            optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
        else if (Options.Value.DatabaseType == DatabaseType.MsSql)
        {
            string connectionString = SetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(connectionString);
        }
        else if (Options.Value.DatabaseType == DatabaseType.Manual)
        {
            optionsBuilder.UseSqlServer(Options.Value.ManualConnectionString);
            Console.ForegroundColor = ConsoleColor.Yellow;
            
        }

        base.OnConfiguring(optionsBuilder);
    }

    private string SetConnectionString()
    {
        return $@"Data Source={Options.Value.SqlOptions.DataSource};Initial Catalog={Options.Value.SqlOptions.DatabaseName};Persist Security Info=True;MultipleActiveResultSets=True;User ID={Options.Value.SqlOptions.UserID};Password={Options.Value.SqlOptions.Password}";
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
