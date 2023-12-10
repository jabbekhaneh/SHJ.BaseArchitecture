using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseArchitecture.Shared.Dynamic;
using SHJ.BaseFramework.EntityFrameworkCore;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;
public class EFPageRepository : BaseEFRepository<EfDbContext, Page>, ICommandPageRepository
{
    public EFPageRepository(EfDbContext context) : base(context)
    {

    }
}
