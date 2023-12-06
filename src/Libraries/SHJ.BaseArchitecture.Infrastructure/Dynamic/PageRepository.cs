using SHJ.BaseArchitecture.Domain.Dynamic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHJ.BaseArchitecture.Infrastructure.Dynamic;

public class PageRepository : IPageRepository
{
    public ICommandPageRepository Command { get; }
    public IQueryPageRepository Query { get; }
    public PageRepository(ICommandPageRepository command, IQueryPageRepository query)
    {
        Command = command;
        Query = query;
    }
}
