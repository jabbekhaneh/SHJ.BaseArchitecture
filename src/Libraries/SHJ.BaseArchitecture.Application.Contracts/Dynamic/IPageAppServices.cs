﻿using SHJ.BaseArchitecture.Application.Contracts.Dynamic.DTOs;

namespace SHJ.BaseArchitecture.Application.Contracts.Dynamic;

public interface IPageAppServices
{
    Task Create(CreatePageDto input);
    Task Update(UpdatePageDto input);
    Task<GetPageByIdDto> GetById(Guid id);
}
