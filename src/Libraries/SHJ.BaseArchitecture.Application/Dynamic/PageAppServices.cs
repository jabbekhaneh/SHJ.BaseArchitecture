using Microsoft.AspNetCore.Mvc;
using SHJ.BaseArchitecture.Application.Contracts.Dynamic;
using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseFramework.AspNet.Attributes;
using SHJ.BaseFramework.AspNet.Services;
using SHJ.BaseFramework.Repository;

namespace SHJ.BaseArchitecture.Application.Dynamic;


[ControllerName("Page")]
public class PageAppServices : BaseAppService<Page>, IPageAppServices
{

    private readonly IBaseCommandUnitOfWork _unitOfWork;
    private readonly PageManager _manager;
    public PageAppServices(IBaseCommandUnitOfWork unitOfWork, PageManager manager)
    {
        _unitOfWork = unitOfWork;
        _manager = manager;
    }

    [HttpPost]
    public async Task Create(CreatePageDto input)
    {
        await _manager.Insert(input.Title);
        _unitOfWork.Commit();
    }

    [HttpPut]
    public async Task Update(UpdatePageDto input)
    {
        await _manager.Update(input.Id, input.Title);
        await _unitOfWork.CommitAsync();
    }


    [HttpGet]
    public async Task<GetPageByIdDto> GetById(Guid id)
    {
        return new GetPageByIdDto();
    }
}


