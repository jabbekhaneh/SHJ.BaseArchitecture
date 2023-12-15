using Microsoft.AspNetCore.Mvc;
using SHJ.BaseArchitecture.Application.Contracts.Dynamic;
using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;
using SHJ.BaseArchitecture.Domain.Dynamic;
using SHJ.BaseArchitecture.Shared;
using SHJ.BaseArchitecture.Shared.Dynamic;
using SHJ.BaseFramework.AspNet.Attributes;
using SHJ.BaseFramework.AspNet.Services;
using SHJ.BaseFramework.Repository;
using SHJ.ExceptionHandler;

namespace SHJ.BaseArchitecture.Application.Dynamic;


[ControllerName("Page")]
public class PageAppServices : BaseAppService<Page>, IPageAppServices
{
    private readonly IPageRepository _repository;
    private readonly BaseCommandUnitOfWork _unitOfWork;

    public PageAppServices(IPageRepository repository, BaseCommandUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task Create(CreatePageDto input)
    {
        if (await _repository.Query.IsExistByTitleAsync(input.Title.ToLower()))
            throw new BaseBusinessException(GlobalErrorCodes.DublicatePageTitle);

        var newPage = new Page(input.Title);
        await _repository.Command.InsertAsync(newPage);

        _unitOfWork.Commit();
    }
}


