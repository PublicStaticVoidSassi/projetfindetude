using Volo.Abp.Application.Services;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
namespace UniFlowCRM.Emails;

public class EmailAppService :
  CrudAppService<Email,
  EmailDto,
  Guid,
  PagedAndSortedResultRequestDto,
  CreateUpdateEmailDto
  >, IEmailAppService
{
    public EmailAppService(IRepository<Email, Guid> repository) : base(repository)
    {

    }
}
