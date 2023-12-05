using Microsoft.Extensions.Options;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseFramework.Dapper;
using SHJ.BaseFramework.Shared;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;
public class DapperBlogRepository : BaseDapperSqlServerData<Page>, IQueryPageRepository
{
    public DapperBlogRepository(IOptions<BaseOptions> options) : base(options)
    {

    }
}
