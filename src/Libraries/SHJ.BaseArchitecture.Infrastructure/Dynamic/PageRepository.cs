﻿using SHJ.BaseArchitecture.Shared.Dynamic;

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
