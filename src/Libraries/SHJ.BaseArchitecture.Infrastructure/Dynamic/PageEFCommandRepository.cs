using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseArchitecture.Shared.Dynamic;
using SHJ.BaseFramework.EntityFrameworkCore;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;
public class PageEFCommandRepository : BaseCommandEFRepository<EfDbContext, Page>, ICommandPageRepository
{
    public PageEFCommandRepository(EfDbContext context) : base(context)
    {

    }
}
