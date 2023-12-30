using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SHJ.BaseArchitecture.Application.Contracts.Dynamic;
using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseFramework.AspNet.Services;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseArchitecture.Application.Dynamic.v1;


[BaseControllerName("Page")]
public class PageAppServices : BaseAppService<Page>, IPageAppServices
{
    private readonly PageManager _manager;

    public PageAppServices(IBaseCommandRepository<Page> commandRepository, IBaseQueryableRepository<Page> queryableRepository, IMapper mapper, IBaseCommandUnitOfWork unitOfWork, PageManager manager) : base(commandRepository, queryableRepository, mapper, unitOfWork)
    {
        _manager = manager;
    }

    [HttpPost]
    public async Task Create(CreatePageDto input)
    {
        await _manager.Insert(input.Title);
        await UnitOfWork.CommitAsync();
    }

    [HttpPut]
    public async Task Update(UpdatePageDto input)
    {
        _manager.Update(input.Id, input.Title);
        await UnitOfWork.CommitAsync();
    }

    [HttpGet]
    public async Task<GetPageByIdDto> GetById(Guid id)
    {
        return new GetPageByIdDto();
    }
}


