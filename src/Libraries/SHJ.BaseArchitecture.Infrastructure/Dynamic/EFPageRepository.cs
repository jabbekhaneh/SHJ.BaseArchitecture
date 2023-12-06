using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Domain.Dynamic.Repositories;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseFramework.EntityFrameworkCore;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;
public class EFPageRepository : BaseEFRepository<EfDbContext, Page>, ICommandPageRepository
{
    public EFPageRepository(EfDbContext context) : base(context)
    {

    }
}
