﻿using Dapper;
using Microsoft.Extensions.Options;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Domain.Dynamic.Repositories;
using SHJ.BaseFramework.Dapper;
using SHJ.BaseFramework.Shared;
using System.Xml.Linq;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;
public class DapperPageRepository : BaseDapperSqlServerData<Page>, IQueryPageRepository
{
    public DapperPageRepository(IOptions<BaseOptions> options) : base(options)
    {

    }

    public async Task<bool> IsExistByTitleAsync(string title)
    {
        string query = "select count(1) from Pages where Title=@name";
        return await Connection.ExecuteScalarAsync<bool>(query, new { title });
    }
}
