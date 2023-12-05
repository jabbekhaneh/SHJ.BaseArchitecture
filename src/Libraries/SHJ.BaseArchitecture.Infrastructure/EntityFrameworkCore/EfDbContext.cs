using Microsoft.EntityFrameworkCore;
using SHJ.BaseArchitecture.Domain.Dynamic;

namespace SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;

public class EfDbContext : DbContext
{
    public virtual DbSet<Page> Pages { get; set; }
}
