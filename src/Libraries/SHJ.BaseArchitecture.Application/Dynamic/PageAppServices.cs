using Microsoft.AspNetCore.Mvc;
using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseFramework.AspNet.Services;
using SHJ.BaseFramework.Repository;


namespace SHJ.BaseArchitecture.Application.Dynamic;


public class PageAppServices : BaseAppService<Page>
{
    private readonly PageManager _manager;
    private readonly BaseCommandUnitOfWork _unitOfWork;
    public PageAppServices(PageManager manager, BaseCommandUnitOfWork unitOfWork)
    {
        _manager = manager;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task Create(CreatePageDto input)
    {
         
        await _manager.Create(input.Title);

        _unitOfWork.Commit();
    }
}
