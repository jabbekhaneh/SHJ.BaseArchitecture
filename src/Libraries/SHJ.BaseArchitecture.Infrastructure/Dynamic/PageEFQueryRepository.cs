using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Infrastructure.EntityFrameworkCore;
using SHJ.BaseArchitecture.Shared.Dynamic;
using SHJ.BaseFramework.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;

public class PageEFQueryRepository : BaseQueryEFRepository<EfDbContext, Page>, IQueryPageRepository
{
    public PageEFQueryRepository(EfDbContext context) : base(context)
    {
    }
}
